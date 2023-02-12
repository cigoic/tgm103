using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net.Http.Headers;

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
        /// 取得部落格文章全部清單(首頁使用)
        /// </summary>
        /// <returns></returns>
        public IResult GetArticles()
        {
            return _context.Articles
                  //.Include(a => a.ArticleTitleImage)
                  //.Include(a => a.Tags)
                  //.ToListAsync()
                  // is IEnumerable<Article> articles
                  .Select(a => new ArticleDescriptionModel
                  {
                      Id = a.Id,
                      Title = a.Title,
                      Description = a.Description,
                      ModifiedDate = a.ModifiedDate,
                  })
                  is IEnumerable<ArticleDescriptionModel> articles
                  ? Results.Ok(articles)
                  : Results.NotFound(new { Status = false, Message = "找無內容!" });
        }

        /// <summary>
        /// 取得特定作者的文章清單
        /// </summary>
        /// <returns></returns>
        public async Task<IResult> GetMembersArticles(int articleId)
        {
            if (articleId == 0)
                return Results.NotFound(new { Status = false, Message = "找無會員相關文章!" });

            var memberId = _context.Articles
                .FirstOrDefaultAsync(a => a.Id == articleId)
                .Result?.MemberId;
            if (memberId == 0)
                return Results.NotFound(new { Status = false, Message = "找無會員相關文章!" });

            return await _context.Articles
            .Where(m => m.MemberId == memberId)
            //.Include(a => a.ArticleTitleImage)
            //.Include(a => a.ArticleContentImages)
            //.Include(a => a.Tags)
            .ToListAsync()
             is IEnumerable<Article> articles
             //.Select(a => new ArticleDescriptionModel
             //{
             //    Id = a.Id,
             //    Title = a.Title,
             //    Description = a.Description,
             //    ModifiedDate = a.ModifiedDate,
             //})
             //is IEnumerable<ArticleDescriptionModel> articles
             ? Results.Ok(articles)
             : Results.NotFound(new { Status = false, Message = "找無會員相關文章!" });
        }

        /// <summary>
        /// 取得部落格文章
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns>Results.OK(Article model)</returns>
        /// <returns>Results.NotFound</returns>
        [ActionName("GetById")]
        public async Task<IResult> GetByIdAsync(int ArticleId)
        {
            int prevId = GetPrevArticleId(ArticleId);   // 前一篇文章 ID
            int nextId = GetNextArticleId(ArticleId);

            var article = await _context.Articles
                .Include(a => a.ArticleTitleImage)
                .Include(a => a.ArticleContentImages)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == ArticleId);

            var model = new ArticleDetailsModel
            {
                Id = ArticleId,
                MemberName = _context.Members.Find(article.MemberId).Name,
                Title = article.Title,
                Content = article.Content,
                PrevArticleId = prevId,
                NextArticleId = nextId,
                CreatedDate = article.CreatedDate,
                PrevArticleCreateAt = _context.Articles.FirstOrDefault(a => a.Id == prevId).CreatedDate,
                NextArticleCreateAt = _context.Articles.FirstOrDefault(a => a.Id == nextId).CreatedDate,
                PrevArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == prevId).Title,
                NextArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == nextId).Title
            };

            return (model != null)
                   ? Results.Ok(model)
                   : Results.NotFound(new { Status = false, Message = "找無此文章!" });
        }

        public IResult CountCategories()
        {
            Dictionary<string, int> count = GetCategoriesCount();
            return Results.Ok(count);
        }

        /// <summary>
        /// 取得特定分類的文章列表
        /// </summary>
        /// <param name="categoryType">文章的分類類型</param>
        /// <returns></returns>
        public IResult GetCategoriesPost(string categoryType)
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .Where(a => a.ArticleCategory.Type == categoryType)
                .Select(a => new ArticleDescriptionModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ModifiedDate = a.ModifiedDate,
                })
                is IEnumerable<ArticleDescriptionModel> articles
                ? Results.Ok(articles)
                : Results.NotFound(new { Status = false, Message = "無法取回分類的文章列表" });
        }

        /// <summary>
        /// 計算部落格各分類的文章數量
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, int> GetCategoriesCount()
        {
            var count = new Dictionary<string, int>();
            var articles = _context.Articles.Include(a => a.ArticleCategory).OrderBy(a => a.ArticleCategory.Type);

            foreach (var article in articles)
            {
                if (count.ContainsKey(article.ArticleCategory.Type))
                {
                    count[article.ArticleCategory.Type]++;
                }
                else
                {
                    count[article.ArticleCategory.Type] = 1;
                }
            }

            return count;
        }

        /// <summary>
        /// 取回最新文章列表
        /// </summary>
        /// <param name="numberOfArticles">要取回的文章篇數</param>
        /// <returns></returns>
        public IResult GetLastestPost(int numberOfArticles = 3)
        {
            return _context.Articles
                .OrderByDescending(a => a.CreatedDate)
                .Take(numberOfArticles)
                .Select(a => new ArticleLastestPostModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    CreatedDate = a.CreatedDate,
                })
                is IEnumerable<ArticleLastestPostModel> articles
                ? Results.Ok(articles)
                : Results.NotFound(new { Status = false, Message = "無法取回最新文章列表" });
        }

        /// <summary>
        /// 找尋上一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId">當前文章 ID</param>
        /// <returns></returns>
        private int GetPrevArticleId(int CurrentArticleId)
        {
            var PrevArticle = _context.Articles
                           .OrderBy(a => a.CreatedDate)
                           .Where(a => a.Id < CurrentArticleId)
                           .LastOrDefault();

            if (PrevArticle == null)
                return CurrentArticleId;

            var PrevArticleId = PrevArticle.Id;
            return PrevArticleId;
        }

        /// <summary>
        /// 找尋下一篇文章 ID, 如果找無, 回傳目前文章 ID
        /// </summary>
        /// <param name="CurrentArticleId">當前文章 ID</param>
        /// <returns></returns>
        private int GetNextArticleId(int CurrentArticleId)
        {
            var NextArticle = _context.Articles
                            .OrderBy(a => a.CreatedDate)
                            .Where(a => a.Id > CurrentArticleId)
                            .FirstOrDefault();

            if (NextArticle == null)
                return CurrentArticleId;

            var NextArticleId = NextArticle.Id;
            return NextArticleId;
        }

        /// <summary>
        /// 取得特定文章內容
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns></returns>
        public async Task<IResult> DetailsAsync(int ArticleId)
        {
            try
            {
                var article = await _context.Articles
                    .Include(a => a.ArticleTitleImage)
                    .Include(a => a.ArticleContentImages)
                    .Include(a => a.Tags)
                    .FirstOrDefaultAsync(a => a.Id == ArticleId);
                if (article == null)
                {
                    return Results.NotFound(new { Status = false, Message = "找無相關文章內容!" });
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Results.NoContent();
        }

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
                    CategoryId = (article.CategoryId <= 1) ? 1 : article.CategoryId,
                };
                if (model == null)
                    return Results.NotFound(new { Status = false, Message = "文章建立失敗!" });

                // TODO 影像？
                //if (article.Image != null)
                {
                    //Save article.Image.FileName;
                }

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

        [ActionName("GetTagsById")]
        public IResult GetTagsByIdAsync(int? id)
        {
            if (id > 0)
            {
                return _context.Articles.Where(a => a.Id == id).Select(a => a.Tags)
                    is IEnumerable<Tag> tags
                ? Results.Ok(tags)
                : Results.NoContent();
            }
            else
            {
                return _context.Tags.Select(t => new ArticleTagModel
                {
                    Id = t.Id,
                    Type = t.Type
                }) is IEnumerable<ArticleTagModel> tags
                    ? Results.Ok(tags)
                    : Results.NoContent();
            }
        }

        /// <summary>
        /// 上傳圖片
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public async Task<IResult> UploadImage([FromForm] IFormCollection images)
        //public async Task<IResult> UploadImage([FromForm] IFormFile image)
        {
            if (images == null || images.Count <= 0)
                return Results.NotFound(new { Status = false, Message = "圖片媒體有誤，無法上傳！" });

            //var rootPath = $@"{_env.WebRootPath}\images\ckeditor";
            var rootPath = $@"{_env.WebRootPath}\ckfinder\userfiles\files";
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            string filePath = "";
            string fileName = "";
            foreach (var image in images.Files)
            {
                fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                //fileName = Path.GetFileName(image.FileName);
                if (string.IsNullOrEmpty(fileName)) return Results.NotFound(new { success = false, uploaded = false });

                filePath = Path.Combine(rootPath, fileName);
                // TODO 將圖片位置存入資料庫！
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            return Results.Ok(new
            {
                fileName = $"{fileName}",
                uploaded = true,
                url = $"https://localhost:7082/ckfinder/userfiles/files"
                //resourceType = "Images",//"Files",
                //currentFolder = new
                //{
                //    path = "/",
                //    //url = "/images/ckeditor/",  //"/ckfinder/userfiles/files/",
                //    url = $"{rootPath}",    //"/ckfinder/userfiles/files/",
                //    acl = 255
                //},
                //fileName = $"{fileName}",
                //uploaded = true
            });

            //return Results.Ok();
        }
    }
}