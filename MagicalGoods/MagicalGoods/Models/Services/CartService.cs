using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
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
        public async Task<Cart> AddCartToUser(int userId)
        {
            Cart cart = new Cart()
            {
                UserId = userId
            };
            await _storeContext.AddAsync(cart);
            return cart;
        }

        public async Task<Cart> GetCartByID(int id)
        {
            var result = await _storeContext.Carts.FindAsync(id);
            return result;
        }
    }
}
