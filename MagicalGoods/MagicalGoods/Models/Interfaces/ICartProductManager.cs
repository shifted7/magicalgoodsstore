using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Interfaces
{
    interface ICartProductManager
    {
        //Gets
        public Task<List<CartProduct>> GetAllProductsForCart(string userId);
        public Task<CartProduct> GetCartProductById(int cartProductId);

        //add
        public Task AddProductToCart(CartProduct cartProduct);

        //update quant
        public Task<int> UpdateProductQuantity(int cartProductId, int newQuantity);

        //remove
        public Task RemoveProduct(int cartProductId);

    }
}
