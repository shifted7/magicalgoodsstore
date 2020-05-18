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

        /// <summary>
        /// Adds a new empty cart to the user with the given userId
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <returns>Resulting new cart</returns>
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

        /// <summary>
        /// Gets the current cart of the user with the given userId from the database
        /// </summary>
        /// <param name="userId">The ID of the user</param>
        /// <returns>Resulting cart</returns>
        public async Task<Cart> GetCartByUserID(string userId)
        {
            var cart = _storeContext.Carts.Where(cart => cart.UserId == userId)
                                          .FirstOrDefault();

            if (cart == null)
            {
                await AddCartToUser(userId);
            }

            var result = _storeContext.Carts.Where(cart => cart.UserId == userId)
                                            .Include(cart => cart.CartProducts)
                                            .ThenInclude(cartProduct => cartProduct.Product)
                                            .FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Deletes the cart with the given cartId from the database
        /// </summary>
        /// <param name="cartId">The ID of the cart to delete</param>
        /// <returns>Task result</returns>
        public async Task RemoveCartByID(int cartId)
        {
            Cart cartToDelete = await _storeContext.Carts.FindAsync(cartId);
            _storeContext.Remove(cartToDelete);
            await _storeContext.SaveChangesAsync();
        }

        /// <summary>
        /// Unassigns the cart with the given cartId from its user in the database
        /// </summary>
        /// <param name="cartId">The ID of the cart to unassign</param>
        /// <returns>Task result</returns>
        public async Task RemoveCartFromUser(int cartId)
        {
            Cart cartToRemoveFromUser = await _storeContext.Carts.FindAsync(cartId);
            cartToRemoveFromUser.UserId = null;
            await _storeContext.SaveChangesAsync();
        }
    }
}
