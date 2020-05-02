using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagicalGoods.Data;
using MagicalGoods.Models;
using MagicalGoods.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MagicalGoods.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdministrationController : Controller
    {
        private readonly IProductManager _product;

        public AdministrationController(IProductManager product)
        {
            _product = product;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _product.GetAllProductsAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var product = await _product.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Description,Image")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _product.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            Product getProduct = await _product.GetProductByIdAsync(id);
            if (getProduct == null)
            {
                return NotFound();
            }
            return View(getProduct);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Description,Image")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _product.UpdateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var product = await _product.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.RemoveProductByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
