using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers
{
    public class BlogController : Controller
    {
        private readonly ShopContext _context;

        public BlogController(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // TODO:    需改善撈資料的效率
            var articles = await _context.Articles.ToListAsync();

            var vm = new List<ArticleModel>();

            foreach (var article in articles)
            {
                vm.Add(new ArticleModel
                {
                    MemberName = _context.Members.Where(m => m.MemberId == article.MemberId).FirstOrDefault()!.Name,
                    FileName = _context.ArticleContentImages.Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.FileName,
                    Title = _context.Articles.Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.Title,
                    Content = _context.Articles.Where(m => m.ArticleId == article.ArticleId).FirstOrDefault()!.Content
                });
            }

            return View(vm.AsEnumerable());
        }
        public IActionResult Sidebar()
        {
            return View();
        }
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
