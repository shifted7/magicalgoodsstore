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
    public class ProductModel : PageModel
    {
        private IProductManager _productService { get; set; }

        public ProductModel(IProductManager productService)
        {
            _productService = productService;
        }

        public Product CurrentProduct { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            CurrentProduct = result;
            return Page();
        }
    }
}
