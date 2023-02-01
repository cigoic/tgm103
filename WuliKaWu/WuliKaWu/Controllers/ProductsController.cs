<<<<<<< HEAD
<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> Productvue (#6)
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;
using static WuliKaWu.Data.Enums.Common;
=======
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

>>>>>>> [修正] ProductsController Action Method 命名規則與添加生成智慧文件說明的註解，修正分頁使用的高亮度背景 CSS 樣式，修正 Product 使用 Grid Sidebar 樣版首頁的檢視頁面
=======
using System;
>>>>>>> [更新] 商品新增頁面套版調整完成，幫書嫻改CartModel及CartApiController
=======

>>>>>>> [更新] 整合衣服搭配樣版頁面至 Product > Match
using WuliKaWu.Data;
<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
using WuliKaWu.Models.ApiModel;
>>>>>>> [修正]商品編輯檢視頁面的儲存編輯按鈕連動

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        }

        /// <summary>
        /// Shop 首頁 - Standard Syle
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexOne()
        {
            return View();
=======
>>>>>>> test (#3)
        }
=======
       }
>>>>>>> Productvue (#6)

<<<<<<< HEAD
        public IActionResult Match()
        { return View(); }
=======
        public async Task<IActionResult> Index2()
=======
        }

        /// <summary>
        /// Shop 首頁 - Standard Syle
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexOne()
>>>>>>> [修正] ProductsController Action Method 命名規則與添加生成智慧文件說明的註解，修正分頁使用的高亮度背景 CSS 樣式，修正 Product 使用 Grid Sidebar 樣版首頁的檢視頁面
        {
            return View();
        }
>>>>>>> 套版到Product的Index 將原先的Index暫時先改為Index2 (目前破版ing)

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

        public IActionResult Match()
        { return View(); }

        // GET: Products/Details/5
<<<<<<< HEAD
        public async Task<IActionResult> ProductDetails(int id = 2)
=======
        public async Task<IActionResult> ProductDetails(int id = 7) //TODO 預設值要修改回來(清空) 可能ProductId之後要考慮要自動編號或我們給予編號
>>>>>>> [更新]微調檢視頁面(商品新增/商品明細/layout)及ProductController
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

            //return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD
        //// POST: Products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ProductModel product)
        //{
        //    Product prd = new Product
        //    {
        //        //ProductId = product.ProductId,
        //        ProductName = product.ProductName,                
        //        CategoryId = (int)product.Category,                
        //        Price = product.Price,                
        //        SellingPrice = Convert.ToDecimal(product.SellingPrice),
        //        Comment = product.Comment,
                

        //        Tags = product.Tag.Select(x=> new Data.Tag { Id = x}).ToList(),
        //        Colors = product.Color.Select(x => new Data.Color { Id = x }).ToList(),
        //        Size = (Size)Enum.Parse(typeof(Size), product.Size),
        //        PicturePath = product.PicturePath,
        //    };

        //    _context.Products.Add(prd);
        //    await _context.SaveChangesAsync();

        //    return View();

        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(product);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //return View(product);
        //}
=======
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create(Product product)
<<<<<<< HEAD

=======
>>>>>>> [修正]商品新增檢視頁面的按鍵綁定完成(但新增完導回的頁面仍要調整)
=======
        public async Task<IActionResult> Create(ProductModel product)
>>>>>>> [修正]ProductController中的Create的參數型態
        {
            Product prd = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Color = product.Color,
                Size = product.Size,
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
>>>>>>> [更新] 商品新增頁面套版調整完成，幫書嫻改CartModel及CartApiController

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
<<<<<<< HEAD
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
=======

            var vm = new ProductModel();

            vm.ProductId = product.ProductId;
            vm.ProductName = product.ProductName;
            vm.Color = product.Color;
            vm.Size = product.Size;
            vm.Category = product.Category;
            vm.PicturePath = $"~/images/{product.PicturePath}";
            vm.Price = product.Price;
            vm.Discount = product.Discount > 0 ? true : false;
            vm.SellingPrice = (product.SellingPrice).ToString();
            //vm.Tag = (Data.Enums.Common.Tag)product.Tag;

            return View(vm);
>>>>>>> [修正]商品編輯檢視頁面的儲存編輯按鈕連動
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModel model)
<<<<<<< HEAD
        {
            throw new NotImplementedException();
            //if (id != model.ProductId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    var product = _context.Products.Where(p => p.ProductId == model.ProductId).FirstOrDefault();

            //    product.ProductId = model.ProductId;
            //    product.ProductName = model.ProductName;
            //    product.Color = model.Color;
            //    product.Size = (Size)Enum.Parse(typeof(Size), model.Size);
            //    //product.Category = model.Category;
            //    product.PicturePath = model.PicturePath;
            //    product.Price = model.Price;
            //    product.Discount = Convert.ToDecimal(model.Discount);
            //    product.SellingPrice = decimal.Parse(model.SellingPrice);

            //    try
            //    {
            //        _context.Update(product);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ProductExists(model.ProductId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}
            //return View(model);
=======

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
                product.Size = model.Size;
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
>>>>>>> [修正]商品編輯檢視頁面的儲存編輯按鈕連動
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

<<<<<<< HEAD
            return View();
=======
            var vm = new ProductModel();
            vm.ProductId = product.ProductId;
            vm.PicturePath = $"~/images/{product.PicturePath}";
            vm.ProductName = product.ProductName;
            vm.Color = product.Color;
            vm.Size = product.Size;
            vm.Category = product.Category;
            vm.Price = product.Price;
            vm.SellingPrice = (product.SellingPrice).ToString();

            return View(vm);
>>>>>>> [修正]商品刪除檢視頁面的圖片顯示綁定
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