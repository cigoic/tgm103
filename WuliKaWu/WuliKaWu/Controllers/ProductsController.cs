using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WuliKaWu.Data;

namespace WuliKaWu.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;
        private readonly IWebHostEnvironment environment;

        public ProductsController(ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        /// <summary>
        /// Shop  首頁 - Grid Sidebar
        /// </summary>
        /// <returns></returns>
        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// Shop 首頁 - Standard Syle
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexOne()
        {
            return View();
        }

        /// <summary>
        /// 產品圖檔上傳
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>

        [HttpPost]
        public string Upload(IFormFile file)
        {
            if (file.Length > 1024000000) return "檔案過大";

            if (file == null || file.Length <= 0) return "請選擇圖檔";

            if (file.ContentType == "image/")
            {
                var root = environment.WebRootPath;
                var fileName = DateTime.Now.Ticks + file.FileName;
                var path = $@"{root}\uploadimg\{fileName}";

                using (var fs = System.IO.File.Create(root))
                    file.CopyTo(fs);

                return "上傳成功";
            }
            else
            {
                return "不支援該格式的檔案上傳";
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> ProductDetails(int id = 1) //TODO 預設值要修改回來(清空) 可能ProductId之後要考慮要自動編號或我們給予編號
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)

        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Color,Size,Image,Price,Comment,StarRate,Category,Tag")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ShopContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}