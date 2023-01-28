using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
=======
        public BlogController(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var articles = await _context.Articles.FirstOrDefaultAsync();

            var vm = new ArticleModel();
            vm.MemberName = _context.Members.Where(m => m.MemberId == articles.MemberId).FirstOrDefault().Name;
            vm.FileName = _context.ArticleContentImages.Where(i => i.ArticleId == articles.ArticleId).FirstOrDefault().FileName;
            vm.Title = _context.Articles.Where(i => i.ArticleId == articles.ArticleId).FirstOrDefault().Title;
            vm.Content = _context.Articles.Where(i => i.ArticleId == articles.ArticleId).FirstOrDefault().Content;

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
        }
>>>>>>> [更新] 修改 _Layout 中 AboutUs, Blog...以及 Vue 的引用連結. 新增相關控制器與檢視頁面
        public IActionResult Sidebar()
        {
            return View();
        }
<<<<<<< HEAD

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
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
>>>>>>> [更新] 修改 _Layout 中 AboutUs, Blog...以及 Vue 的引用連結. 新增相關控制器與檢視頁面
