using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        
        
        private IPaymentManager _paymentService;

        [BindProperty]
        public CheckoutInput Input { get; set; }

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
            result = _paymentService.Run(Input);
            if(result == "Response recieved.")
            {
                return RedirectToPage("/Checkout/Order");
            }
            return Page();
        }

        public class CheckoutInput
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Shipping Address Line 1")]
            public string ShippingAddressLine1 { get; set; }

            [Display(Name = "Shipping Address Line 2")]
            public string ShippingAddressLine2 { get; set; }

            [Required]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Required]
            [Display(Name = "StateOrProvince")]
            public string StateOrProvince { get; set; }

            [Required]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required]
            [Display(Name = "Payment")]
            public string Payment { get; set; }
        }




    }
}
