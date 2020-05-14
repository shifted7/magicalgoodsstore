using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Services
{
    public class OrderService : IOrderManager
    {
        private StoreDbContext _storeContext;

        public OrderService(StoreDbContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task CreateOrder(Order order)
        {
            _storeContext.Add(order);
            await _storeContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(int id)
        {
            Order order = await _storeContext.Orders.FindAsync(id);
            _storeContext.Remove(order);
            await _storeContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = await _storeContext.Orders.Include(order => order.Cart)
                                                            .ThenInclude(cart => cart.CartProducts)
                                                            .ThenInclude(cartProduct => cartProduct.Product)
                                                            .ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderByID(int id)
        {
            var result = await _storeContext.Orders.FindAsync(id);
            return result;
        }
    }
}
