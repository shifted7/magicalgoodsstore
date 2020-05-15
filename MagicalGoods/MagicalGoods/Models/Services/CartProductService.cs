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
        private readonly UserManager<ApplicationUser> _userManager;

        public CartProductService(StoreDbContext storeContext, UserManager<ApplicationUser> userManager)
        {
            _storeContext = storeContext;
            _userManager = userManager;
        }
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

        public async Task<List<CartProduct>> GetAllProductsForCart(string userId)
        {
            if (userId == null)
            {
                return null;
            }

            // TODO: ADd Logic to if the cart doesn't exist...then create one for them (fail safe)
            var userCart = await _storeContext.Carts.FirstOrDefaultAsync(entry => entry.UserId == userId);
            if (userCart != null)
            {
                var cartProducts = await _storeContext.CartProducts
                .Where(cartProduct => cartProduct.CartID == userCart.ID)
                .Include(cartProduct => cartProduct.Product)
                .ToListAsync();
                return cartProducts;
            }

            return null;
           
        }

        public async Task<CartProduct> GetCartProductById(int cartProductId)
        {
            var result = await _storeContext.CartProducts.FindAsync(cartProductId);
            return result;
        }

        public async Task RemoveProduct(int cartProductId)
        {
            CartProduct cartProductToDelete = await _storeContext.CartProducts.FindAsync(cartProductId);
            _storeContext.Remove(cartProductToDelete);
            await _storeContext.SaveChangesAsync();
        }

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
