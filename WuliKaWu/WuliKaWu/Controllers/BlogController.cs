using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Extensions;

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

            return View();
        }

        /// <summary>
        /// 檢視頁面 - 新增文章
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 檢視頁面 - 編輯文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0) RedirectToAction("Index");

            var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (article == null || article.MemberId != User.Claims.GetMemberId())
                return RedirectToAction("Index", "Blog");

            ViewBag.ArticleId = id;
            return View();
        }
    }
}