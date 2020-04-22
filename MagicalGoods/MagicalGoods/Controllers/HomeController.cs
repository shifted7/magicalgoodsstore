using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MagicalGoods.Controllers
{
    public class HomeController : Controller
    {
        private IProductManager _product;

        public HomeController(IProductManager product)
        {
            _product = product;
        }
        public async Task<IActionResult> Index()
        {
            var render = await _product.GetAllProductsAsync();
            return View(render);
        }
    }
}