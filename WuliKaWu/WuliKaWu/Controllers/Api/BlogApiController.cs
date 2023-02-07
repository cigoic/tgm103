using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers.Api
{
    /// <summary>
    /// 部落格 API 控制器
    /// </summary>
<<<<<<< HEAD
<<<<<<< HEAD
    [Route("api/Blog/[action]/{ArticleId?}")]
=======
    [Route("api/Blog/[action]")]
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======
    [Route("api/Blog/[action]/{ArticleId?}")]
>>>>>>> [更新] 繼續修改部落格相關檢視頁面, 改寫用 Vue.js 撈取資料
    [ApiController]
    public class BlogApiController : ControllerBase
    {
        private readonly ShopContext _context;
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======

>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
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
<<<<<<< HEAD
<<<<<<< HEAD
        [ActionName("GetArticleById")]
=======
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======
        [ActionName("GetArticleById")]
>>>>>>> [更新] 繼續修改部落格相關檢視頁面, 改寫用 Vue.js 撈取資料
        public async Task<IResult> GetArticleByIdAsync(int ArticleId)
        {
            return await _context.Articles.FindAsync(ArticleId)
                is Article model
                    ? Results.Ok(model)
                    : Results.NotFound();
        }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> [更新] 修正 Blog API Controller 中，（找尋上下文章 ID）Methods 中的 Lambda/LINQ 查詢語句
        /// <summary>
        /// 找尋上一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
<<<<<<< HEAD
        [Route("api/Blog/PrevArticle/{CurrentArticleId}")]
        [HttpGet]
        public IResult GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticle = _context.Articles
                           .OrderBy(a => a.CreatedDate)
                           .Where(a => a.ArticleId < CurrentArticleId)
                           .LastOrDefault();

            if (PrevArticle == null)
                return Results.Ok(new { CurrentArticleId });

            var PrevArticleId = PrevArticle.ArticleId;
            return Results.Ok(new { PrevArticleId });
        }

        /// <summary>
        /// 找尋下一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
        [Route("api/Blog/NextArticle/{CurrentArticleId}")]
        [HttpGet]
        public IResult GetNextArticleId(int CurrentArticleId)
        {
            var NextArticle = _context.Articles
                            .OrderBy(a => a.CreatedDate)
                            .Where(a => a.ArticleId > CurrentArticleId)
                            .FirstOrDefault();

            if (NextArticle == null)
                return Results.Ok(new { CurrentArticleId });

            var NextArticleId = NextArticle.ArticleId;
            return Results.Ok(new { NextArticleId });
        }

=======
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======
        [Route("api/Blog/NextArticle")]
=======
=======
>>>>>>> [更新] 修正 Blog API Controller 中，（找尋上下文章 ID）Methods 中的 Lambda/LINQ 查詢語句
        [Route("api/Blog/PrevArticle/{CurrentArticleId}")]
        [HttpGet]
        public IResult GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticle = _context.Articles
                           .OrderBy(a => a.CreatedDate)
                           .Where(a => a.Id < CurrentArticleId)
                           .LastOrDefault();

            if (PrevArticle == null)
                return Results.Ok(new { CurrentArticleId });

            var PrevArticleId = PrevArticle.Id;
            return Results.Ok(new { PrevArticleId });
        }

        /// <summary>
        /// 找尋下一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
        [Route("api/Blog/NextArticle/{CurrentArticleId}")]
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
        [HttpGet]
        public IResult GetNextArticleId(int CurrentArticleId)
        {
            var NextArticle = _context.Articles
                            .OrderBy(a => a.CreatedDate)
                            .Where(a => a.Id > CurrentArticleId)
                            .FirstOrDefault();

            if (NextArticle == null)
                return Results.Ok(new { CurrentArticleId });

            var NextArticleId = NextArticle.Id;
            return Results.Ok(new { NextArticleId });
        }

>>>>>>> [更新] 繼續修改部落格相關檢視頁面, 改寫用 Vue.js 撈取資料
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
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======
}
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
