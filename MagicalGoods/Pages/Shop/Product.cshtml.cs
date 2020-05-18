using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Shop
{
    public class ProductModel : PageModel
    {

        // uses dependency injection to use a method from the IProductManager Interface
        private IProductManager _productService { get; set; }
        public string UserId { get; set; }

        private UserManager<ApplicationUser> _userManager;
        private ICartProductManager _cartProductService;
        private ICartManager _cartService;

        public ProductModel(IProductManager productService, UserManager<ApplicationUser> userManager, ICartProductManager cartProductService, ICartManager cartService)
        {
            _productService = productService;
            _userManager = userManager;
            _cartProductService = cartProductService;
            _cartService = cartService;
        }

        public Product CurrentProduct { get; set; }

        // As the user click on a specific product from the shop page, this OnGet method uses the GetProductByID method from the product interface to display the product by that specific ID
        public async Task<IActionResult> OnGet(int id)
        {
            UserId = _userManager.GetUserId(User);

            var result = await _productService.GetProductByIdAsync(id);
            CurrentProduct = result;
            return Page();
        }

        public async Task<IActionResult> OnPost(int productId)
        {

            string userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToPage("/Account/Login");
            }
            var result = await _cartService.GetCartByUserID(userId);
            int cartId = result.ID;

            CartProduct cartProduct = new CartProduct()
            {
                CartID = cartId,
                ProductID = productId,
                Quantity = 1
            };
            await _cartProductService.AddProductToCart(cartProduct);
            return RedirectToPage("/Shop/Index");
        }
    }
}
