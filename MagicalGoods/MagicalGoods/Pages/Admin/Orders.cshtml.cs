using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MagicalGoods.Models;
using Microsoft.AspNetCore.Authorization;
using MagicalGoods.Models.Interfaces;

namespace MagicalGoods.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class OrdersModel : PageModel
    {
        private IOrderManager _orderManager;

        public OrdersModel(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public List<MagicalGoods.Models.Order> Orders { get; set; }
        public async Task OnGet()
        {
            Orders = await _orderManager.GetAllOrders();
            //return Page();
        }
    }
}
