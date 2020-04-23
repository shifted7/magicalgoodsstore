using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private IProductManager _product;

        public List<Product> Products {get; set; }

        public IndexModel(IProductManager product)
        {
            _product = product;
        }
        public async Task<IActionResult> OnGet()
        {
            Products = await _product.GetAllProductsAsync();

            return Page();

        }
    }
}
