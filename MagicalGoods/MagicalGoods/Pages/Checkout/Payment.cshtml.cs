using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Cart
{
    public class PaymentModel : PageModel
    {
        private IPaymentManager _paymentService;
        public string result;
        public PaymentModel(IPaymentManager paymentService)
        {
            _paymentService = paymentService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            result = _paymentService.Run();
            if(result == "Response recieved.")
            {
                return RedirectToPage("/Checkout/Order");
            }
            return Page();
        }
    }
}
