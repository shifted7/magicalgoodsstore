using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicalGoods.Pages.Shop
{
    public class IndexModel : PageModel
    {
        // using dependency injection to bring in the IProductManager interface to use a method from within. 
        private IProductManager _product;
        private UserManager<ApplicationUser> _userManager;

        //propert for a list of our products
        public List<Product> Products {get; set; }
        public string UserId { get; set; }

        public IndexModel(IProductManager product, UserManager<ApplicationUser> userManager)
        {
            _product = product;
            _userManager = userManager;
        }

        // When the user tries to access the shop page, this method goes into the IProductManager interface and uses the AllGetProducts method from it to display the list of ALL products from the database.
        public async Task<IActionResult> OnGet()
        {
            UserId = _userManager.GetUserId(User);
            Products = await _product.GetAllProductsAsync();

            return Page();

        }
    }
}
