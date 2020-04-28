using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Interfaces
{
    interface ICartProductManager
    {
        //Get
        public Task<List<CartProduct>> GetAllProductsForCart(int cartId);

        //public List<CartProduct> GetCartProductByIds(int cartId, int productId);
        //add
        public Task<CartProduct> AddProductToCart(int productId, int cartId, int productQuantity);
        //update quant
        public Task<int> UpdateProductQuantity(int productId, int cartId, int productQuantity);
        //remove
        public Task RemoveProduct(int productId, int cartId);

    }
}
