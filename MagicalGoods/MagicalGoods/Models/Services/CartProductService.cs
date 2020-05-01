using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
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

        public CartProductService(StoreDbContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task AddProductToCart(CartProduct cartProduct)
        {
            _storeContext.Add(cartProduct);
            await _storeContext.SaveChangesAsync();
        }

        public async Task<List<CartProduct>> GetAllProductsForCart(string userId)
        {
            if (userId == null)
            {
                return null;
            }
            var userCart = await _storeContext.Carts.FirstOrDefaultAsync(entry => entry.UserId == userId);
            var cartProducts = await _storeContext.CartProducts
                .Where(cartProduct => cartProduct.CartID == userCart.ID)
                .Include(cartProduct => cartProduct.Product)
                .ToListAsync();                                 
            return cartProducts;
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
