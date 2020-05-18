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
        private IOrderManager _orderManager;

        public List<CartProduct> CartProducts { get; set; }
        public string Email { get; set; }


        public OrderModel(IEmailSender emailSender, ICartProductManager cartProduct, UserManager<ApplicationUser> userManager, ICartManager cart, IOrderManager orderManager)
        {
            _emailSender = emailSender;
            _cartProduct = cartProduct;
            _userManager = userManager;
            _cart = cart;
            _orderManager = orderManager;
        }
        public async Task<IActionResult> OnGet()
        {
            var userId = _userManager.GetUserId(User);
            if(userId == null)
            {
                return RedirectToPage("/Account/Login");
            }
            string userName = _userManager.GetUserName(User);
            CartProducts = await _cartProduct.GetAllProductsForCart(userId);
            decimal totalPrice = 0;
            var cart = await _cart.GetCartByUserID(userId);

            var order = new MagicalGoods.Models.Order()
            {
                Cart = cart,
                CustomerName = userName,
                DateOfOrder = DateTime.Now,
                TotalPrice = totalPrice
            };

            await _orderManager.CreateOrder(order);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h1> Your order is on the way! </h1>");
            foreach (var cartProduct in CartProducts)
            {
                sb.AppendLine($"<h2>{cartProduct.Product.Name}</h2>");
                sb.AppendLine($"<p>Quantity: {cartProduct.Quantity}</p>");
                sb.AppendLine($"<p>Price: {cartProduct.Product.Price * cartProduct.Quantity}</p>");
            }
            foreach (var cartProduct in CartProducts)
            {
                totalPrice += cartProduct.Product.Price * cartProduct.Quantity;
            }
            order.TotalPrice = totalPrice;
            sb.AppendLine($"<a href='https://magicalgoodsstore.azurewebsites.net/'>Shop Some more!</a>");

            await _emailSender.SendEmailAsync(userName, "Receipt", sb.ToString());
            await _cart.RemoveCartFromUser(cart.ID);
            await _cart.AddCartToUser(userId);
            return RedirectToPage("/Checkout/Receipt");
        }
    }
}
