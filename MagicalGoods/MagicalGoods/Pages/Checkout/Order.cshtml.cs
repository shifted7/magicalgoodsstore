using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Checkout
{
    public class OrderModel : PageModel
    {
        private IEmailSender _emailSender;
        private ICartProductManager _cartProduct;
        private UserManager<ApplicationUser> _userManager;
        private ICartManager _cart;

        public List<CartProduct> CartProducts { get; set; }
        public string Email { get; set; }


        public OrderModel(IEmailSender emailSender, ICartProductManager cartProduct, UserManager<ApplicationUser> userManager, ICartManager cart)
        {
            _emailSender = emailSender;
            _cartProduct = cartProduct;
            _userManager = userManager;
            _cart = cart;
        }
        public async Task<IActionResult> OnGet()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1> Your order is on the way! </h1>");

            var userId = _userManager.GetUserId(User);
            CartProducts = await _cartProduct.GetAllProductsForCart(userId);


            foreach (var cartProduct in CartProducts)
            {
                sb.AppendLine($"<h2>{cartProduct.Product.Name}</h2>");
                sb.AppendLine($"<p>Quantity: {cartProduct.Quantity}</p>");
                sb.AppendLine($"<p>Price: {cartProduct.Product.Price * cartProduct.Quantity}</p>");
            }
            sb.AppendLine($"<a href='https://magicalgoodsstore.azurewebsites.net/'>Shop Some more!</a>");

            string email = _userManager.GetUserName(User);

            await _emailSender.SendEmailAsync(email, "Receipt", sb.ToString());

            await _cart.AddCartToUser(userId);

            return RedirectToPage("/Checkout/Receipt");
        }
    }
}
