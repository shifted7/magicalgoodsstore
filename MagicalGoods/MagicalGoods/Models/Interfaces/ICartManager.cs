using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Interfaces
{
    interface ICartManager
    {
        public Task<Cart> AddCartToUser(string userId);
        public Task<Cart> GetCartByID(int id);

    }
}
