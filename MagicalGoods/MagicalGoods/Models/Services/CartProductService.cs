using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Services
{
    public class CartProductService : ICartProductManager
    {
        private readonly StoreDbContext _storeContext;
        private readonly ICartManager _cartService;

        public CartProductService(StoreDbContext storeContext, ICartManager cartService)
        {
            _storeContext = storeContext;
            _cartService = cartService;
        }

        /// <summary>
        /// Adds the inputted cartproduct to the user's cart. If the item is already in the user's cart, adds to the quantity instead.
        /// </summary>
        /// <param name="cartProduct">The product to add to the user's current cart</param>
        /// <returns>Task result</returns>
        public async Task AddProductToCart(CartProduct cartProduct)
        {
            var cartProducts = await GetAllProductsForCartById(cartProduct.CartID);

            foreach (var cartItem in cartProducts)
            {
                if (cartItem.ProductID == cartProduct.ProductID)
                {
                    await UpdateProductQuantity(cartItem.ID, cartItem.Quantity + cartProduct.Quantity);
                    return;
                }
            }

            _storeContext.Add(cartProduct);
            await _storeContext.SaveChangesAsync();

        }

        /// <summary>
        /// Gets all the cartproducts in the cart with the given cart ID in the database
        /// </summary>
        /// <param name="cartId">The cart ID</param>
        /// <returns>The resulting list of cartproducts in the cart</returns>
        public async Task<List<CartProduct>> GetAllProductsForCartById (int cartId)
        {
            var cart = await _storeContext.Carts.FirstOrDefaultAsync(entry => entry.ID == cartId);
            if (cart != null)
            {
                var cartProducts = await _storeContext.CartProducts
                .Where(cartProduct => cartProduct.CartID == cart.ID)
                .Include(cartProduct => cartProduct.Product)
                .ToListAsync();
                return cartProducts;
            }
            return null;
        }

        /// <summary>
        /// Gets all the cartproducts for the current cart of the user matching the user ID from the database
        /// </summary>
        /// <param name="userId">The user's ID</param>
        /// <returns>The resulting list of cartproducts</returns>
        public async Task<List<CartProduct>> GetAllProductsForCart(string userId)
        {
            if (userId == null)
            {
                return null;
            }

            var userCart = await _storeContext.Carts.FirstOrDefaultAsync(entry => entry.UserId == userId);

            if (userCart == null)
            {
                await _cartService.AddCartToUser(userId);
            }

            var cartProducts = await _storeContext.CartProducts
            .Where(cartProduct => cartProduct.CartID == userCart.ID)
            .Include(cartProduct => cartProduct.Product)
            .ToListAsync();
            return cartProducts;
           
        }

        /// <summary>
        /// Gets the cartproduct matching the cartproduct ID from the database
        /// </summary>
        /// <param name="cartProductId">The cartproduct ID</param>
        /// <returns>The resulting cartproduct</returns>
        public async Task<CartProduct> GetCartProductById(int cartProductId)
        {
            var result = await _storeContext.CartProducts.FindAsync(cartProductId);
            return result;
        }

        /// <summary>
        /// Deletes the cartproduct that matches the given cartproduct ID from the database
        /// </summary>
        /// <param name="cartProductId">The ID of the cartproduct</param>
        /// <returns>Task result</returns>
        public async Task RemoveProduct(int cartProductId)
        {
            CartProduct cartProductToDelete = await _storeContext.CartProducts.FindAsync(cartProductId);
            _storeContext.Remove(cartProductToDelete);
            await _storeContext.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the quantity of the cartproduct with the given ID to the new quantity in the database
        /// </summary>
        /// <param name="cartProductId">The ID of the cartproduct</param>
        /// <param name="newQuantity">The quantity to update to</param>
        /// <returns>The new quantity</returns>
        public async Task<int> UpdateProductQuantity(int cartProductId, int newQuantity)
        {

            CartProduct cartProductToUpdate = await _storeContext.CartProducts.FindAsync(cartProductId);
            cartProductToUpdate.Quantity = newQuantity;
            _storeContext.Update(cartProductToUpdate);
            await _storeContext.SaveChangesAsync();
            return cartProductToUpdate.Quantity;
        }
    }
}
