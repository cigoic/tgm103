using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers
{
    /// <summary>
    /// 部落格文章控制器
    /// </summary>
    public class BlogController : Controller
    {
        private readonly ShopContext _context;

        private IWebHostEnvironment _env;

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

        public IActionResult Sidebar()
        {
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
                return NotFound();

            var article = _context.Articles.Where(a => a.Id == ArticleId).FirstOrDefault();
            if (article == null)
                return NotFound();

            int prevId = GetPrevArticleId(ArticleId);   // 前一篇文章 ID
            int nextId = GetNextArticleId(ArticleId);

            var model = new ArticleDetailsModel()
            {
                ArticleId = ArticleId,
                MemberName = _context.Members.AsEnumerable().Where(m => m.MemberId == article!.MemberId).FirstOrDefault()!.Name,
                FileName = _context.ArticleContentImages.AsEnumerable().Where(m => m.Id == article!.Id).FirstOrDefault()!.PicturePath,
                Title = article.Title,
                Content = article.Content,
                TitleImageFileName = $"~/{_context.ArticleTitleImages.AsEnumerable().Where(t => t.Id == article!.Id).FirstOrDefault()!.PicturePath}",
                ContentImageFileNames = new List<string>(),
                PrevArticleId = prevId,
                NextArticleId = nextId,
                CreateAt = article.CreatedDate,
                PrevArticleCreateAt = _context.Articles.FirstOrDefault(a => a.Id == prevId).CreatedDate,
                NextArticleCreateAt = _context.Articles.FirstOrDefault(a => a.Id == nextId).CreatedDate,
                PrevArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == prevId).Title,
                NextArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == nextId).Title,
            };

            var images = _context.ArticleContentImages.Where(c => c.Id == article!.Id).ToList();
            foreach (var img in images)
            {
                var imgPath = $"~/{img.PicturePath}";
                model.ContentImageFileNames.Add(imgPath);
            }

            return View(model);
        }

        // GET  /Blog/Create
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST /Blog/Create
        /// <summary>
        /// 建立部落格文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [Authorize]
        [ActionName("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ArticleCreateModel article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //string articleContent = "版面讓我們不停更是彩色同事，打開每個人，幸福狀況谷歌您是部隊不懂唯一導致權限風雲漫畫及其，新年筆者來的居住優質我說，利潤出席以來思路最大服裝許多人物巨大，回覆收到醫藥建設點點資源加入時間同事聯繫看法感動頻率客戶進行，家電一聲應當比如三大看著期限，雙方明顯殺手晶片，好了大家都參觀形式國際已被，因為金幣親自只有模擬線上死了廣播留下激動監管新人私服元素告訴我，投入新手效果網絡哪些屬性，通過右鍵內心顯然達到全市，你自己很有有限買賣對手兒童值得故意整合生意，烏日形象忽然開關安排自行專用免費電影程度群眾求購全家部落，漢化滑鼠公佈，防止新竹步驟找不到古代應用做好西安證券產品符合接着老婆，來說民族跟我未經願意，要在浙江結合教育活動說什麼提示訊息方便免費版，和他此時而已落實病毒沉默奧客軍隊細節擔心課堂重要，優點有時面議遭遇軍事一切要有合同日本如有本論壇，兩個廣大別的，女孩子。";
            int maxLength = 64;

            Article model = new Article
            {
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                MemberId = User.Claims.GetMemberId(),
                Title = article.Title,
                Content = article.Content,
                Description = article.Content.Length <= maxLength
                    ? article.Content : article.Content.Substring(0, maxLength) + "...",
                CategoryId = article.CategoryId,
            };

            _context.Articles.Add(model);

            await _context.SaveChangesAsync();

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
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Articles == null)
        //    {
        //        return NotFound();
        //    }

        //    var article = await _context.Articles
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(article);
        //}

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
               .OrderBy(a => a.CreatedDate)
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

        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            // Save the image file to the desired location
            var rootPath = $@"{_env.WebRootPath}/images/cheditor";
            var filePath = Path.Combine(rootPath, image.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Return a success response
            return Json(new { Status = true, Message = "成功上傳" });
        }
    }
}