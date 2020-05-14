using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Services
{
    public class CartService : ICartManager
    {
        private readonly StoreDbContext _storeContext;

        public CartService(StoreDbContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<Cart> AddCartToUser(string userId)
        {
            Cart cart = new Cart()
            {
                UserId = userId
            };

            _storeContext.Carts.Add(cart);
            await _storeContext.SaveChangesAsync();
            return cart;
        }

        public Cart GetCartByUserID(string userId)
        {
            var result = _storeContext.Carts.Where(cart => cart.UserId == userId)
                                            .Include(cart => cart.CartProducts)
                                            .ThenInclude(cartProduct => cartProduct.Product)
                                            .FirstOrDefault();
            return result;
        }

        public async Task RemoveCartByID(int cartId)
        {
            Cart cartToDelete = await _storeContext.Carts.FindAsync(cartId);
            _storeContext.Remove(cartToDelete);
            await _storeContext.SaveChangesAsync();
        }

        public async Task RemoveCartFromUser(int cartId)
        {
            Cart cartToRemoveFromUser = await _storeContext.Carts.FindAsync(cartId);
            cartToRemoveFromUser.UserId = null;
            await _storeContext.SaveChangesAsync();
        }
    }
}
