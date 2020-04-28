using MagicalGoods.Data;
using MagicalGoods.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicalGoods.Models.Services
{
    public class CartProductService : ICartProductManager
    {
        private readonly StoreDbContext _storeContext;

        public CartProductService(StoreDbContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<CartProduct> AddProductToCart(int productId, int cartId, int productQuantity)
        {
            CartProduct cartProduct = new CartProduct()
            {
                CartID = cartId,
                ProductID = productId,
                Quantity = productQuantity
            };

            await _storeContext.CartProducts.AddAsync(cartProduct);
            await _storeContext.SaveChangesAsync();

            return cartProduct;
        }

        public async Task<List<CartProduct>> GetAllProductsForCart(int cartId)
        {
            var result = await _storeContext.CartProducts.Where(x => x.CartID == cartId).ToListAsync();
                                                         
            return result;
        }

        //public List<CartProduct> GetCartProductByIds(int cartId, int productId)
        //{
        //    var result = _storeContext.CartProducts.Where(x => x.CartID == cartId && x.ProductID == productId).Select(x => new CartProduct()
        //    {
        //        CartID = cartId,
        //        ProductID = productId
        //    }).ToList();

        //    return result;
        //}

        public async Task RemoveProduct(int productId, int cartId)
        {
            CartProduct cartProduct = new CartProduct()
            {
                ProductID = productId,
                CartID = cartId
            };

            _storeContext.Remove(cartProduct);
            await _storeContext.SaveChangesAsync();
        }

        public async Task<int> UpdateProductQuantity(int productId, int cartId, int productQuantity)
        {
            CartProduct cartProduct = new CartProduct()
            {
                ProductID = productId,
                CartID = cartId,
                Quantity = productQuantity
            };

            _storeContext.Update(cartProduct);
            await _storeContext.SaveChangesAsync();
            return cartProduct.Quantity;
        }
    }
}
