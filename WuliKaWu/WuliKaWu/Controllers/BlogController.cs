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
            var articles = await _context.Articles.FirstOrDefaultAsync();

            var vm = new ArticleModel();
            vm.MemberName = _context.Members.Where(m => m.MemberId == articles.MemberId).FirstOrDefault().Name;
            vm.FileName = _context.ArticleContentImages.Where(i => i.ArticleId == articles.ArticleId).FirstOrDefault().FileName;
            vm.Title = _context.Articles.Where(i => i.ArticleId == articles.ArticleId).FirstOrDefault().Title;
            vm.Content = _context.Articles.Where(i => i.ArticleId == articles.ArticleId).FirstOrDefault().Content;

            return View(vm);
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
