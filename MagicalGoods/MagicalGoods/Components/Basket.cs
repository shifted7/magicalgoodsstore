using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MagicalGoods.Components
{
    [ViewComponent]
    public class Basket : ViewComponent
    {
        private ICartProductManager _cartProduct;

        public List<CartProduct> UserCartProducts { get; set; }

        public Basket(ICartProductManager cartProduct)
        {
            _cartProduct = cartProduct;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            //List<CartProduct> cartProducts = await _cartProduct.GetAllProductsForCart(userId);
            UserCartProducts = await _cartProduct.GetAllProductsForCart(userId);
            return View(UserCartProducts);
        }

    }
}
