using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Interfaces
{
    public interface IProductManager
    {
        //Create
        Task<Product> CreateProductAsync(Product product);

        //Read
        Task<Product> GetProductByIdAsync(int productId);
        Task<List<Product>> GetAllProductsAsync();

        //Update
        Task UpdateProductAsync(Product product);

        //Delete
        Task RemoveProductByIdAsync(int productId);
    }
}
