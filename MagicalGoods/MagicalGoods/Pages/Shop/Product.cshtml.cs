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

        // uses dependency injection to use a method from the IProductManager Interface
        private IProductManager _productService { get; set; }

        public ProductModel(IProductManager productService)
        {
            _productService = productService;
        }

        public Product CurrentProduct { get; set; }

        // As the user click on a specific product from the shop page, this OnGet method uses the GetProductByID method from the product interface to display the product by that specific ID
        public async Task<IActionResult> OnGet(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            CurrentProduct = result;
            return Page();
        }
    }
}
