using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class OrderDetailsModel : PageModel
    {
        private IOrderManager _orderManager;
        private ICartManager _cart;
        private UserManager<ApplicationUser> _userManager;

        public MagicalGoods.Models.Order Order { get; set; }


        public OrderDetailsModel(ICartManager cart, UserManager<ApplicationUser> userManager, IOrderManager orderManager)
        {
            _cart = cart;
            _userManager = userManager;
            _orderManager = orderManager;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Order = await _orderManager.GetOrderByID(id);
            if (Order.Cart == null)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cart.GetCartByUserID(userId);
                Order.Cart = cart;
            }
            return Page();

        }
    }
}
