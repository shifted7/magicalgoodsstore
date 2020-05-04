using System;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Cart
{
    public class UpdateModel : PageModel
    {

        private readonly ICartProductManager _cartProduct;

        [BindProperty]
        public CartProduct CartProduct { get; set; }

        public UpdateModel(ICartProductManager cartProduct)
        {
            _cartProduct = cartProduct;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _cartProduct.UpdateProductQuantity(CartProduct.ID, CartProduct.Quantity);
            return RedirectToPage("/Cart/Index");
        }
    }
}
