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

        /// <summary>
        /// Creates an order to display on the admin orders page.
        /// </summary>
        /// <param name="order">takes in an order</param>
        public async Task CreateOrder(Order order)
        {
            _storeContext.Add(order);
            await _storeContext.SaveChangesAsync();
        }

        /// <summary>
        /// creates ability for the admin to delete the order 
        /// </summary>
        /// <param name="id">the id of the order that wants to be deleted</param>
        /// <returns></returns>
        public async Task DeleteOrder(int id)
        {
            Order order = await _storeContext.Orders.FindAsync(id);
            _storeContext.Remove(order);
            await _storeContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all the orders that were created to display to the admin 
        /// </summary>
        /// <returns>the details of the order</returns>
        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = await _storeContext.Orders.Include(order => order.Cart)
                                                            .ThenInclude(cart => cart.CartProducts)
                                                            .ThenInclude(cartProduct => cartProduct.Product)
                                                            .ToListAsync();
            return orders;
        }

        /// <summary>
        /// Gets all the orders to display as well as including the cartproducts with the products and displays the list
        /// </summary>
        /// <param name="id">the order id</param>
        /// <returns>the order details</returns>
        public async Task<Order> GetOrderByID(int id)
        {
            var result = await _storeContext.Orders.Where(order=> order.ID == id)
                                                    .Include(order => order.Cart)
                                                    .ThenInclude(cart => cart.CartProducts)
                                                    .ThenInclude(cartProduct => cartProduct.Product)
                                                    .FirstOrDefaultAsync();
            return result;
        }
    }
}
