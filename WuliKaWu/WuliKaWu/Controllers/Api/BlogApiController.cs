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

<<<<<<< HEAD
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
        public BlogApiController(ShopContext context)
=======
        private readonly IWebHostEnvironment _env;

        public BlogApiController(ShopContext context, IWebHostEnvironment environment)
>>>>>>> [更新] 持續修改新增文章上傳圖片, 目前後端檔案有上傳，但是前端頁面回提示警告說無法上傳檔案
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
<<<<<<< HEAD
<<<<<<< HEAD
        [ActionName("GetArticleById")]
=======
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======
        [ActionName("GetArticleById")]
<<<<<<< HEAD
>>>>>>> [更新] 繼續修改部落格相關檢視頁面, 改寫用 Vue.js 撈取資料
        public async Task<IResult> GetArticleByIdAsync(int ArticleId)
=======
        public async Task<IResult> GetArticleIdAsync(int ArticleId)
>>>>>>> [新增] 修改 Artical 資料內容類別定義表, 新增部落格發文功能, 將 CK Editor 純文字內容加入資料庫
        {
            return await _context.Articles.FindAsync(ArticleId)
                is Article model
                    ? Results.Ok(model)
                    : Results.NotFound(new { Status = false, Message = "找無內容!" });
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

<<<<<<< HEAD
>>>>>>> [更新] 繼續修改部落格相關檢視頁面, 改寫用 Vue.js 撈取資料
        // GET  api/Blog/GetArticleDetails/{ArticleId}
=======
        // GET  api/Blog/Details/{ArticleId}
>>>>>>> [新增] 修改 Artical 資料內容類別定義表, 新增部落格發文功能, 將 CK Editor 純文字內容加入資料庫
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
<<<<<<< HEAD
<<<<<<< HEAD
}
=======
}
>>>>>>> [更新] 新增部落格 API 控制器(初版)
=======
}
>>>>>>> [更新] 部落格首頁、內容檢視頁面跳轉頁面（如：上下一筆文章、當前文章）的超連結邏輯
