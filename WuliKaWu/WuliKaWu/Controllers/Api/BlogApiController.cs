using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers.Api
{
    /// <summary>
    /// 部落格 API 控制器
    /// </summary>
    [Route("api/Blog/[action]/{ArticleId?}")]
    [ApiController]
    public class BlogApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public BlogApiController(ShopContext context)
        {
            _context = context;
        }

        // GET  api/Blog/GetArticles
        /// <summary>
        /// 取得部落格文章全部清單
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        // GET  api/Blog/GetArticleById/{ArticleId}
        /// <summary>
        /// 取得部落格文章
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns>Results.OK(Article model)</returns>
        /// <returns>Results.NotFound</returns>
        [ActionName("GetArticleById")]
        public async Task<IResult> GetArticleByIdAsync(int ArticleId)
        {
            return await _context.Articles.FindAsync(ArticleId)
                is Article model
                    ? Results.Ok(model)
                    : Results.NotFound();
        }

        [Route("api/Blog/PrevArticle/{CurrentArticleId}")]
        [HttpGet]
        public IActionResult GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticleId = _context.Articles.Where(a => a.ArticleId == CurrentArticleId).Skip(-1).FirstOrDefault().ArticleId;
            return Ok(new { PrevArticleId });
        }

        [Route("api/Blog/NextArticle/{CurrentArticleId}")]
        [HttpGet]
        public IActionResult GetNextArticleId(int CurrentArticleId)
        {
            var NextArticleId = _context.Articles.Where(a => a.ArticleId == CurrentArticleId).Skip(1).FirstOrDefault().ArticleId;
            return Ok(new { NextArticleId });
        }

        // GET  api/Blog/GetArticleDetails/{ArticleId}
        /// <summary>
        /// 取得特定文章內容
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns></returns>
        public async Task<IResult> GetArticleDetailsAsync(int ArticleId)
        {
            var article = await _context.Articles.FindAsync(ArticleId);
            if (article == null)
            {
                return Results.NotFound();
            }

            _context.Update(article);
            await _context.SaveChangesAsync();

            return Results.NoContent();
        }

        // POST api/Blog/CreateArticle
        /// <summary>
        /// 建立部落格文章
        /// </summary>
        /// <param name="article">表單欄位資料</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResult> CreateArticleAsync(ArticleModel article)
        {
            //_context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return Results.Ok();
        }

        // DELETE   api/Blog/DeleteArticle/{ArticleId}
        /// <summary>
        /// 刪除部落格文章
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns></returns>
        public async Task<IResult> DeleteArticleAsync(int ArticleId)
        {
            if (await _context.Articles.FindAsync(ArticleId) is Article article)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return Results.Ok(article);
            }

            return Results.NotFound();
        }
    }
}