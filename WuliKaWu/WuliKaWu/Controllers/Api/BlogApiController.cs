using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
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

        private readonly IWebHostEnvironment _env;

        public BlogApiController(ShopContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _env = environment;
        }

        /// <summary>
        /// 取得部落格文章全部清單
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Articles
                .Include(a => a.ArticleTitleImage)
                .Include(a => a.ArticleContentImages)
                .Include(a => a.Tags)
                //.Select(a => new NewArticleModel { ... })
                .ToListAsync();
        }

        /// <summary>
        /// 取得部落格文章
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns>Results.OK(Article model)</returns>
        /// <returns>Results.NotFound</returns>
        [ActionName("GetArticleById")]
        public async Task<IResult> GetArticleIdAsync(int ArticleId)
        {
            return await _context.Articles.FindAsync(ArticleId)
                is Article model
                    ? Results.Ok(model)
                    : Results.NotFound(new { Status = false, Message = "找無內容!" });
        }

        /// <summary>
        /// 找尋上一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId"></param>
        /// <returns></returns>
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

        // GET  api/Blog/Details/{ArticleId}
        /// <summary>
        /// 取得特定文章內容
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns></returns>
        public async Task<IResult> DetailsAsync(int ArticleId)
        {
            try
            {
                var article = await _context.Articles.FindAsync(ArticleId);
                if (article == null)
                {
                    return Results.NotFound(new { Status = false, Message = "找無文章!" });
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Results.NoContent();
        }

        // POST api/Blog/CreateArticle
        /// <summary>
        /// 建立部落格文章
        /// </summary>
        /// <param name="article">表單欄位資料</param>
        /// <returns></returns>
        [Authorize]
        [ActionName("Create")]
        [HttpPost]
        public async Task<IResult> CreateAsync([FromForm] ArticleCreateModel article)
        {
            try
            {
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
                if (model == null)
                    return Results.NotFound(new { Status = false, Message = "文章建立失敗!" });

                _context.Articles.Add(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Results.Ok(new { Status = true, Message = "文章新增成功!" });
        }

        // DELETE   api/Blog/Delete/{ArticleId}
        /// <summary>
        /// 刪除部落格文章
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IResult> DeleteConfirmed(int id)
        {
            if (await _context.Articles.FindAsync(id) is Article article)
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return Results.Ok(new { Status = true, Message = "文章刪除成功!" });
            }

            return Results.NotFound(new { Status = false, Message = "文章刪除失敗!" });
        }

        /// <summary>
        /// 上傳圖片
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public async Task<IResult> UploadImage([FromForm] IFormCollection images)//List<IFormFile> images)
        {
            if (images == null || images.Count <= 0)
                return Results.NotFound(new { Status = false, Message = "圖片媒體有誤，無法上傳！" });

            var rootPath = $@"{_env.WebRootPath}\images\ckeditor";
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            string filePath = "";
            string fileName = "";
            foreach (var image in images.Files)
            {
                fileName = Path.GetFileName(image.FileName);
                filePath = Path.Combine(rootPath, fileName);
                // TODO 將圖片位置存入資料庫！
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //if (stream == null)
                    //    return Json(new { Status = false, Message = "圖片上傳失敗" });

                    await image.CopyToAsync(stream);
                }
            }

            return Results.Ok(new
            {
                fileName = fileName,
                uploaded = true,
                url = $"{filePath}"
            });
        }
    }
}