using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MagicalGoods.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private ICartProductManager _cartProductService;
        public List<CartProduct> UserCartProducts { get; set; }
        public decimal Total { get; set; }

        public IndexModel(UserManager<ApplicationUser> userManager, ICartProductManager cartProductService)
        {
            _userManager = userManager;
            _cartProductService = cartProductService;
        }
        public async Task<IActionResult> OnGet()
        {
            string userId = _userManager.GetUserId(User);
            if (userId.Length > 0)
            {
                UserCartProducts = await _cartProductService.GetAllProductsForCart(userId);

                foreach (var cartProduct in UserCartProducts)
                {
                    Total = Total + cartProduct.Product.Price * cartProduct.Quantity;
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
