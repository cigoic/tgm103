using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WuliKaWu.Data;
using WuliKaWu.Models;

<<<<<<< HEAD
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

<<<<<<< HEAD
<<<<<<< HEAD
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
<<<<<<< HEAD
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
=======
        public BlogController(ShopContext context)
=======
        private IWebHostEnvironment _env;

        public BlogController(ShopContext context, IWebHostEnvironment environment)
>>>>>>> [更新] Article Details 檢視中部分元素, 改撈取資料庫資料出來顯示
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _env = environment;
        }

        public async Task<IActionResult> IndexAsync()
=======
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
        {
            return View();

            // 當使用前端呼叫請求資料時,註解下面的程式片段
            //var articles = await _context.Articles.ToListAsync();

<<<<<<< HEAD
<<<<<<< HEAD
            return View(vm);
>>>>>>> [更新] Blog Index 檢視可顯示單筆部落格文章與圖片
        }

=======
namespace WuliKaWu.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
=======
            foreach (var article in articles)
            {
                vm.Add(new ArticleModel
                {
                    MemberName = _context.Members.AsEnumerable().Where(m => m.MemberId == article.MemberId).FirstOrDefault()!.Name,
                    FileName = _context.ArticleContentImages.AsEnumerable().Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.FileName,
                    Title = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.Title,
                    Content = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.Content
                });
            }

            return View(vm.AsEnumerable());
>>>>>>> [更新] 部落格首頁可透過逐筆撈取資料庫,顯示文章及標題圖片(使用後端 Razoe syntax 寫法)
=======
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
>>>>>>> [更新] 部落格首頁改用 Vue.js 撈取資料庫文章資料(初版)
        }
<<<<<<< HEAD
>>>>>>> [更新] 修改 _Layout 中 AboutUs, Blog...以及 Vue 的引用連結. 新增相關控制器與檢視頁面
=======

>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
        public IActionResult Sidebar()
        {
            return View();
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯

        /// <summary>
        /// 文章內容
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        [Route("/Blog/Details/{ArticleId}")]
        public IActionResult Details(int ArticleId)
<<<<<<< HEAD
        {
            if (ArticleId <= 0)
                return NotFound();

            var article = _context.Articles.Where(a => a.ArticleId == ArticleId).FirstOrDefault();
            if (article == null)
                return NotFound();

            int prevId = GetPrevArticleId(ArticleId);   // 前一篇文章 ID
            int nextId = GetNextArticleId(ArticleId);

            var model = new ArticleModel()
            {
                ArticleId = ArticleId,
                MemberName = _context.Members.AsEnumerable().Where(m => m.MemberId == article!.MemberId).FirstOrDefault()!.Name,
                FileName = _context.ArticleContentImages.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.FileName,
                Title = article.Title,
                Content = article.Content,
                TitleImageFileName = $"~/{_context.ArticleTitleImages.AsEnumerable().Where(t => t.ArticleId == article!.ArticleId).FirstOrDefault()!.FileName}",
                ContentImageFileNames = new List<string>(),
                PrevArticleId = prevId,
                NextArticleId = nextId,
                CreateAt = article.CreatedDate,
                PrevArticleCreateAt = _context.Articles.FirstOrDefault(a => a.ArticleId == prevId).CreatedDate,
                NextArticleCreateAt = _context.Articles.FirstOrDefault(a => a.ArticleId == nextId).CreatedDate,
                PrevArticleTitle = _context.Articles.FirstOrDefault(a => a.ArticleId == prevId).Title,
                NextArticleTitle = _context.Articles.FirstOrDefault(a => a.ArticleId == nextId).Title,
            };

            var images = _context.ArticleContentImages.Where(c => c.ArticleId == article!.ArticleId).ToList();
            foreach (var img in images)
            {
                var imgPath = $"~/{img.FileName}";
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
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return View();
        }

        /// <summary>
        /// 找尋上一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
        private int GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticle = _context.Articles
               .OrderBy(a => a.CreatedDate)
               .Where(a => a.ArticleId < CurrentArticleId)
               .LastOrDefault();

            if (PrevArticle == null)
                return CurrentArticleId;

            return PrevArticle.ArticleId;
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
                .Where(a => a.ArticleId > CurrentArticleId)
                .FirstOrDefault();

            if (NextArticle == null)
                return CurrentArticleId;

            return NextArticle.ArticleId;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            // Save the image file to the desired location
            var filePath = Path.Combine("path/to/image", image.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Return a success response
            return Json(new { success = true });
        }
    }
}
=======
        public IActionResult Details()
=======
        public IActionResult Details(int ArticleId = 1) // TODO
>>>>>>> [更新] Article Details 檢視中部分元素, 改撈取資料庫資料出來顯示
=======
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
        {
            if (ArticleId <= 0)
                return NotFound();

            var article = _context.Articles.Where(a => a.ArticleId == ArticleId).FirstOrDefault();
            if (article == null)
                return NotFound();

            var model = new ArticleModel()
            {
                ArticleId = ArticleId,
                MemberName = _context.Members.AsEnumerable().Where(m => m.MemberId == article!.MemberId).FirstOrDefault()!.Name,
                FileName = _context.ArticleContentImages.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.FileName,
                Title = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.Title,
                Content = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.Content,
                TitleImageFileName = $"~/{_context.ArticleTitleImages.AsEnumerable().Where(t => t.ArticleId == article!.ArticleId).FirstOrDefault()!.FileName}",
                ContentImageFileNames = new List<string>(),
                PrevArticleId = GetPrevArticleId(ArticleId),
                NextArticleId = GetNextArticleId(ArticleId),
            };

            var images = _context.ArticleContentImages.Where(c => c.ArticleId == article!.ArticleId).ToList();
            foreach (var img in images)
            {
                var imgPath = $"~/{img.FileName}";
                model.ContentImageFileNames.Add(imgPath);
            }

            return View(model);
        }

        // GET  /Blog/Create
        [Authorize]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return View();
        }

        /// <summary>
        /// 找尋上一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
        private int GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticle = _context.Articles
               .OrderBy(a => a.CreatedDate)
               .Where(a => a.ArticleId < CurrentArticleId)
               .LastOrDefault();

            if (PrevArticle == null)
                return CurrentArticleId;

            return PrevArticle.ArticleId;
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
                .Where(a => a.ArticleId > CurrentArticleId)
                .FirstOrDefault();

            if (NextArticle == null)
                return CurrentArticleId;

            return NextArticle.ArticleId;
        }
    }
<<<<<<< HEAD
}
>>>>>>> [更新] 修改 _Layout 中 AboutUs, Blog...以及 Vue 的引用連結. 新增相關控制器與檢視頁面
=======
}
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
