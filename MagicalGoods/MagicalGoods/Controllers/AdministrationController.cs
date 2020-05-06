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
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MagicalGoods.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdministrationController : Controller
    {
        private readonly IProductManager _product;
        public Blob Blob { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }
        public AdministrationController(IProductManager product, IConfiguration configuration)
        {
            _product = product;
            Blob = new Blob(configuration);
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
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Description")] Product product)
        {

            var filePath = Path.GetTempFileName();
            // stream io to save to file location
            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);
            }

            // take the file at temp location to put into the blob storage
            await Blob.UploadFile("products",Image.FileName, filePath);

            // gets the blob from the storage, gives it an address
            var blob = await Blob.GetBlob(Image.FileName, "products");
            // sets the product img to the correct url
            product.Image = blob.Uri.ToString();

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

            var filePath = Path.GetTempFileName();
            // stream io to save to file location
            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);
            }

            // take the file at temp location to put into the blob storage
            await Blob.UploadFile("products", Image.FileName, filePath);

            // gets the blob from the storage, gives it an address
            var blob = await Blob.GetBlob(Image.FileName, "products");
            // sets the product img to the correct url
            product.Image = blob.Uri.ToString();

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
