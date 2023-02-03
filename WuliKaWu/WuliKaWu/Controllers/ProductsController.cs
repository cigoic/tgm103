using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;
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

        public IActionResult Match()
        { return View(); }

        // GET: Products/Details/5
        public async Task<IActionResult> ProductDetails(int id = 2)
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
        public async Task<IActionResult> Create(ProductModel product)
        {
            Product prd = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Color = product.Color,
                Size = (Size)Enum.Parse(typeof(Size), product.Size),
                Category = product.Category,
                PicturePath = product.PicturePath,
                Price = product.Price,
                Discount = Convert.ToDecimal(product.Discount),
                SellingPrice = Convert.ToDecimal(product.SellingPrice),
                Tag = product.Tag
            };

            _context.Products.Add(prd);
            await _context.SaveChangesAsync();

            return View(product);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(product);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            ViewBag.id = id;

            return View();

            //var product = await _context.Products.FindAsync(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //var vm = new ProductModel();

            //vm.ProductId = product.ProductId;
            //vm.ProductName = product.ProductName;
            //vm.Color = product.Color;
            //vm.Size = product.Size.ToString();
            //vm.Category = product.Category;
            //vm.PicturePath = $"~/images/{product.PicturePath}";
            //vm.Price = product.Price;
            //vm.Discount = product.Discount > 0 ? true : false;
            //vm.SellingPrice = (product.SellingPrice).ToString();
            ////vm.Tag = (Data.Enums.Common.Tag)product.Tag;

            //return View(vm);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModel model)

        {
            if (id != model.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product = _context.Products.Where(p => p.ProductId == model.ProductId).FirstOrDefault();

                product.ProductId = model.ProductId;
                product.ProductName = model.ProductName;
                product.Color = model.Color;
                product.Size = (Size)Enum.Parse(typeof(Size), model.Size);
                product.Category = model.Category;
                product.PicturePath = model.PicturePath;
                product.Price = model.Price;
                product.Discount = Convert.ToDecimal(model.Discount);
                product.SellingPrice = decimal.Parse(model.SellingPrice);

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(model.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(model);
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
            ViewBag.id = id;

            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, ProductModel model)
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