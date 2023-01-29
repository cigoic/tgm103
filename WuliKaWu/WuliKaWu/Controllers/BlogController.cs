﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers
{
    public class BlogController : Controller
    {
        private readonly ShopContext _context;

        private IWebHostEnvironment _env;

        public BlogController(ShopContext context, IWebHostEnvironment environment)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _env = environment;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var articles = await _context.Articles.ToListAsync();

            var vm = new List<ArticleModel>();

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
        }
        public IActionResult Sidebar()
        {
            return View();
        }
        public IActionResult Details(int ArticleId = 1) // TODO
        {
            if (ArticleId <= 0)
                return NotFound();

            var article = _context.Articles.Where(a => a.ArticleId == ArticleId).FirstOrDefault();
            if (article == null)
                return NotFound();

            var vm = new ArticleModel()
            {
                MemberName = _context.Members.AsEnumerable().Where(m => m.MemberId == article!.MemberId).FirstOrDefault()!.Name,
                FileName = _context.ArticleContentImages.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.FileName,
                Title = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.Title,
                Content = _context.Articles.AsEnumerable().Where(m => m.ArticleId == article!.ArticleId).FirstOrDefault()!.Content,
                TitleImageFileName = $"~/{_context.ArticleTitleImages.AsEnumerable().Where(t => t.ArticleId == article!.ArticleId).FirstOrDefault()!.FileName}",
                ContentImageFileNames = new List<string>()
            };

            var images = _context.ArticleContentImages.Where(c => c.ArticleId == article!.ArticleId).ToList();
            foreach (var img in images)
            {
                var imgPath = $"~/{img.FileName}";
                vm.ContentImageFileNames.Add(imgPath);
            }

            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticleModel model)
        {
            return View();
        }
    }
}
