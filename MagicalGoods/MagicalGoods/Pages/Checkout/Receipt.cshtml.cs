using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Checkout
{
    public class ReceiptModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private ICartProductManager _cartProductService;
        public List<CartProduct> CheckoutCartProducts { get; set; }
        public decimal Total { get; set; }

        public ReceiptModel(UserManager<ApplicationUser> userManager, ICartProductManager cartProductService)
        {
            _userManager = userManager;
            _cartProductService = cartProductService;
        }
        public async Task<IActionResult> OnGet()
        {
            string userId = _userManager.GetUserId(User);
            if (userId.Length > 0)
            {
                CheckoutCartProducts = await _cartProductService.GetAllProductsForCart(userId);

                foreach (var cartProduct in CheckoutCartProducts)
                {
                    Total += cartProduct.Product.Price * cartProduct.Quantity;
                }
                return Page();
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
