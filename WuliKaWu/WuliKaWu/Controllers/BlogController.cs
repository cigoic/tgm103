using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers
{
    /// <summary>
    /// 部落格文章控制器
    /// </summary>
    public class BlogController : Controller
    {
        private readonly ShopContext _context;

        private readonly IWebHostEnvironment _env;

        public BlogController(ShopContext context, IWebHostEnvironment environment)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _env = environment;
        }

        /// <summary>
        /// 部落格首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();

            // 當使用前端呼叫請求資料時,註解下面的程式片段
            //var articles = await _context.Articles.ToListAsync();

            //var vm = new List<ArticleModel>();

            //foreach (var article in articles)
            //{
            //    vm.Add(new ArticleModel
            //    {
            //        MemberName = _context.Members.AsEnumerable().Where(m => m.MemberId == article.MemberId).FirstOrDefault()!.Name,
            //        FileName = _context.ArticleContentImages.AsEnumerable().Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.FileName,
            //        Title = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.Title,
            //        Content = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.Content
            //    });
            //}

            //return View(vm.AsEnumerable());
        }

        /// <summary>
        /// 顯示作者的所有相關文章
        /// </summary>
        /// <returns></returns>
        public IActionResult Sidebar(int? id = 0)
        {
            if (id <= 0) RedirectToAction("Index");

            ViewBag.ArticleId = id;
            return View();
        }

        /// <summary>
        /// 文章內容
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        [Route("/Blog/Details/{ArticleId}")]
        public IActionResult Details(int ArticleId)
        {
            if (ArticleId <= 0)
                return RedirectToAction("Index");

            ViewBag.ArticleId = ArticleId;
            var article = _context.Articles.FirstOrDefault(a => a.Id == ArticleId);
            if (article == null)
                return RedirectToAction("Index");

            // TODO 可能要改用前端將前後文 ID 帶回
            int prevId = GetPrevArticleId(ArticleId);   // 前一篇文章 ID
            int nextId = GetNextArticleId(ArticleId);

            var model = new ArticleDetailsModel();
            {
                model.Id = ArticleId;
                model.MemberName = _context.Members.FirstOrDefault(m => m.MemberId == article!.MemberId)!.Name;
                //model.FileName = article.ArticleContentImages.FirstOrDefault(i => i.Id == ArticleId).PicturePath;
                model.Title = article.Title;
                model.Content = article.Content;
                //model.TitleImageFileName = $"~/{article.ArticleTitleImages.FirstOrDefault(t => t.Id == ArticleId)!.PicturePath}";
                //model.ContentImageFileNames = new List<string>();
                model.PrevArticleId = prevId;
                model.NextArticleId = nextId;
                model.CreatedDate = article.CreatedDate;
                model.PrevArticleCreateAt = _context.Articles.FirstOrDefault(a => a.Id == prevId).CreatedDate;
                model.NextArticleCreateAt = _context.Articles.FirstOrDefault(a => a.Id == nextId).CreatedDate;
                model.PrevArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == prevId).Title;
                model.NextArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == nextId).Title;
            };

            //foreach (var img in article.ArticleContentImages)
            //{
            //    var imgPath = $"~/{img.PicturePath}";
            //    model.ContentImageFileNames.Add(imgPath);
            //}

            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Blog/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Articles == null)
        //    {
        //        return NotFound();
        //    }

        //    var article = await _context.Articles.FindAsync(id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(article);
        //}

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,MemberId,CreatedDate,ModifiedDate,Title,Content")] Article article)
        //{
        //    if (id != article.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(article);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ArticleExists(article.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(article);
        //}

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articles == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Blog/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Articles == null)
        //    {
        //        return Problem("Entity set 'ShopContext.Articles'  is null.");
        //    }
        //    var article = await _context.Articles.FindAsync(id);
        //    if (article != null)
        //    {
        //        _context.Articles.Remove(article);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ArticleExists(int id)
        //{
        //    return _context.Articles.Any(e => e.Id == id);
        //}

        /// <summary>
        /// 找尋上一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
        private int GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticle = _context.Articles
               .OrderBy(a => a.CreatedDate) // TODO 可能效能會有問題
               .Where(a => a.Id < CurrentArticleId)
               .LastOrDefault();

            if (PrevArticle == null)
                return CurrentArticleId;

            return PrevArticle.Id;
        }

        /// <summary>
        /// 找尋下一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
        private int GetNextArticleId(int CurrentArticleId)
        {
            var NextArticle = _context.Articles
                .OrderBy(a => a.CreatedDate)
                .Where(a => a.Id > CurrentArticleId)
                .FirstOrDefault();

            if (NextArticle == null)
                return CurrentArticleId;

            return NextArticle.Id;
        }

        public async Task<IActionResult> UploadImage([FromForm] IFormCollection images)//List<IFormFile> images)
        {
            if (images == null || images.Count <= 0)
                return Json(new { Status = false, Message = "圖片媒體有誤，無法上傳！" });

            // Save the image file to the desired location
            var rootPath = $@"{_env.WebRootPath}/images/ckeditor";
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            foreach (var image in images.Files)
            {
                var filePath = Path.Combine(rootPath, image.FileName);
                // TODO 將圖片位置存入資料庫！
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //if (stream == null)
                    //    return Json(new { Status = false, Message = "圖片上傳失敗" });

                    await image.CopyToAsync(stream);
                }
            }

            // Return a success response
            return Json(new { Status = true, Message = "成功上傳" });
        }
    }
}