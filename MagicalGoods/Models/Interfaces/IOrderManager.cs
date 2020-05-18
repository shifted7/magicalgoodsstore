using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Interfaces
{
    public interface IOrderManager
    {
        public Task CreateOrder(Order order);
        public Task<Order> GetOrderByID(int id);
        public Task DeleteOrder(int id);

        public Task<List<Order>> GetAllOrders();
    }
}
