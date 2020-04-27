using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Services
{
    public class ProductService : IProductManager
    {
        private StoreDbContext _context { get; } 
        public ProductService(StoreDbContext context)
        {
            _context = context; // Database context brought into service for database operations
        }
        
        /// <summary>
        /// Creates a product database entry according to the inputted product object
        /// </summary>
        /// <param name="product">The product to add to the database. An ID will be assigned to the product upon entry.</param>
        /// <returns>The added product.</returns>
        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Gets a list of all the products in the database.
        /// </summary>
        /// <returns>A list containing all the products in the database, translated from all the database entries.</returns>
        public async Task<List<Product>> GetAllProductsAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        /// <summary>
        /// Gets a product from the database that matches the given id.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve from the database</param>
        /// <returns>The product that matches the given id, translated from the database entry.</returns>
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            return product;
        }

        /// <summary>
        /// Removes the product from the database that matches the given id
        /// </summary>
        /// <param name="productId">The id of the product to delete from the database.</param>
        /// <returns>The task for deleting the given product.</returns>
        public async Task RemoveProductByIdAsync(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the product in the database that matches the given product's id to the other info of the given product.
        /// </summary>
        /// <param name="product">The updated product, with an ID that matches the product to update.</param>
        /// <returns>The task for updating the given product.</returns>
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
