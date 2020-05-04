using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Cart
{
    public class RemoveModel : PageModel
    {
        private readonly ICartProductManager _cartProduct;

        [BindProperty]
        public CartProduct cartProduct { get; set; }

        public RemoveModel(ICartProductManager cartProduct)
        {
            _cartProduct = cartProduct;
        }
        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost()
        {
            await _cartProduct.RemoveProduct(cartProduct.ID);
            return RedirectToPage("/Cart/Index");
        }

        

    }
}
