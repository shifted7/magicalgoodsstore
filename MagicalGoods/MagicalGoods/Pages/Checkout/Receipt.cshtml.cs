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
        private IOrderManager _orderManager;

        public List<CartProduct> CheckoutCartProducts { get; set; }
        public decimal Total { get; set; }

        public ReceiptModel(UserManager<ApplicationUser> userManager, ICartProductManager cartProductService, IOrderManager orderManager)
        {
            _userManager = userManager;
            _cartProductService = cartProductService;
            _orderManager = orderManager;
        }
        public async Task<IActionResult> OnGet()
        {
            string userId = _userManager.GetUserId(User);
            if (userId != null && userId.Length > 0)
            {
                var allOrders = await _orderManager.GetAllOrders();

                CheckoutCartProducts = allOrders.Where(order => order.CustomerName == User.Identity.Name)
                                                .Last()
                                                .Cart.CartProducts;

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
