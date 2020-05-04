using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Interfaces
{
    public interface ICartManager
    {
        public Task<Cart> AddCartToUser(string userId);
        public Cart GetCartByUserID(string userId);

    }
}
