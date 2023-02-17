using ImageMagick;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net.Http.Headers;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;
using WuliKaWu.Models.ApiModel;

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
        /// 判斷用戶是否登入
        /// </summary>
        /// <returns></returns>
        public bool GetLoginStatus()
        {
            return User.Identity.IsAuthenticated;
        }

        /// <summary>
        /// 取得部落格文章全部清單(首頁使用)
        /// </summary>
        /// <returns></returns>
        public IResult GetArticles()
        {
            return _context.Articles
                  .Select(a => new ArticleDescriptionModel
                  {
                      Id = a.Id,
                      Title = a.Title,
                      Description = a.Description,
                      ModifiedDate = a.ModifiedDate,
                      TitleImage = (a.ArticleTitleImage != null)
                        ? a.ArticleTitleImage.PicturePath
                        : $"https://picsum.photos/id/{randIdx()}/600/400",
                  })
                  is IEnumerable<ArticleDescriptionModel> articles
                  ? Results.Ok(articles)
                  : Results.NotFound(new { Status = false, Message = "找無內容!" });
        }

        /// <summary>
        /// 取得特定作者的文章清單
        /// </summary>
        /// <returns></returns>
        public IResult GetMembersArticles(int articleId)
        {
            if (articleId == 0)
                return Results.NotFound(new { Status = false, Message = "找無會員相關文章!" });

            var memberId = _context.Articles
                .FirstOrDefaultAsync(a => a.Id == articleId)
                .Result?.MemberId;
            if (memberId == 0)
                return Results.NotFound(new { Status = false, Message = "找無會員相關文章!" });

            return _context.Articles
            .Include(a => a.ArticleTitleImage)
            .Include(a => a.ArticleContentImages)
            .Include(a => a.Tags)
            .Where(m => m.MemberId == memberId)
             .Select(a => new ArticleMemberPostsModel
             {
                 Id = a.Id,
                 Title = a.Title,
                 Description = a.Description,
                 ModifiedDate = a.ModifiedDate,
                 TitleImage = a.ArticleTitleImage.PicturePath,
             })
             is IEnumerable<ArticleMemberPostsModel> articles
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

            if (article == null)
                Results.NotFound(new { Status = false, Message = "找無此文章!" });

            return new ArticleDetailsModel
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
                NextArticleTitle = _context.Articles.FirstOrDefault(a => a.Id == nextId).Title,
                TitleImage = (article.ArticleTitleImage != null)
                    ? article.ArticleTitleImage.PicturePath
                    : $"https://picsum.photos/id/{randIdx()}/600/400",
            } is ArticleDetailsModel model
                   ? Results.Ok(model)
                   : Results.NotFound(new { Status = false, Message = "找無此文章!" });
        }

        public IResult GetRandomProductPic()
        {
            Random random = new Random();
            int count = _context.Pictures.Count();
            int skip = random.Next(0, count - 1);
            return Path.Combine(_env.WebRootPath, _context.Pictures.Skip(skip).Take(1).FirstOrDefault().PicturePath)
                is string picturePath
                ? Results.Ok(picturePath)
                : Results.NoContent();
        }

        private static int randIdx()
        {
            Random random = new Random();
            return random.Next(0, 1000);
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
                //.Take(numberOfArticles)
                .Select(a => new ArticleLastestPostModel
                {
                    Id = a.Id,
                    MemberName = _context.Members.FirstOrDefault(m => m.MemberId == a.MemberId).Name,
                    Title = a.Title,
                    Description = a.Description,
                    CreatedDate = a.CreatedDate,
                    TitleImage = a.ArticleTitleImage.PicturePath,
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
                const int MAX_DESCRIPTION_LENGTH = 64;

                Article model = new Article
                {
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    MemberId = User.Claims.GetMemberId(),
                    Title = article.Title,
                    Content = article.Content,
                    Description = article.Content.Length <= MAX_DESCRIPTION_LENGTH
                        ? article.Content : article.Content.Substring(0, MAX_DESCRIPTION_LENGTH) + "...",
                    CategoryId = (article.CategoryId <= 1) ? 1 : article.CategoryId,
                    ArticleTitleImage = new ArticleTitleImage(),
                    ArticleContentImages = new List<ArticleContentImage>(),
                };
                if (model == null)
                    return Results.NotFound(new { Status = false, Message = "文章建立失敗!" });

                // 影像
                if (article.Images != null)
                {
                    int cnt = 0;    // 跳過前三筆紀錄(Title, CategoryId, Content)
                    foreach (var key in article.Images.Keys)
                    {
                        var fileName = "";
                        if (cnt > 2 && key.StartsWith("Images[0]"))
                        {
                            // 使用第一張圖做部落格文章 titile image
                            fileName = article.Images[key];
                            model.ArticleTitleImage.PicturePath = fileName;
                        }
                        else if (cnt > 3 && key.StartsWith("Images["))
                        {
                            // 其餘圖片為內文圖片
                            model.ArticleContentImages
                                .Add(new ArticleContentImage
                                {
                                    PicturePath = article.Images[key]
                                });
                        }
                        cnt++;
                    }
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

        /// <summary>
        /// 編輯部落格文章
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IResult> GetEditArticleById(int ArticleId)
        {
            var article = await _context.Articles
                .Include(a => a.ArticleTitleImage)
                .Include(a => a.ArticleContentImages)
                .Include(a => a.Tags)
                .FirstOrDefaultAsync(a => a.Id == ArticleId);

            var contentImgs = article.ArticleContentImages.Select(a => a.PicturePath).ToList();

            var model = new ArticleEditModel
            {
                Id = ArticleId,
                MemberId = article.MemberId,
                MemberName = _context.Members.Find(article.MemberId).Name,
                Title = article.Title,
                Content = article.Content,
                CreatedDate = article.CreatedDate,
                ModifiedDate = article.ModifiedDate,
                CategoryId = article.CategoryId,
            };

            return (model != null)
                   ? Results.Ok(model)
                   : Results.NotFound(new { Status = false, Message = "找無此文章!" });
        }

        [Authorize]
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IResult> EditAsync([FromForm] ArticleUpdateModel model)
        {
            if (model.ArticleId <= 0 || model.MemberId != User.Claims.GetMemberId())
            {
                return Results.NotFound(new { Status = false, Message = "無法編輯" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int MAX_DESCRIPTION_LENGTH = 64;

                    var article = _context.Articles
                        .Include(a => a.ArticleTitleImage)
                        .Include(a => a.ArticleContentImages)
                        .FirstOrDefault(a => a.Id == model.ArticleId);

                    if (article.MemberId != model.MemberId)
                        return Results.NotFound(new { Status = false, Message = "非此篇作者，無法編輯" });

                    article.Title = model.Title;
                    article.Content = model.Content;
                    article.Description = model.Content.Length <= MAX_DESCRIPTION_LENGTH
                        ? model.Content : model.Content.Substring(0, MAX_DESCRIPTION_LENGTH) + "...";
                    article.ModifiedDate = DateTime.UtcNow;
                    article.CategoryId = model.CategoryId;

                    if (article.ArticleTitleImage == null)
                        article.ArticleTitleImage = new ArticleTitleImage();
                    if (article.ArticleContentImages == null)
                        article.ArticleContentImages = new List<ArticleContentImage>();

                    // 影像
                    if (model.Images != null)
                    {
                        // 有無重複的圖？先去除舊的標題圖  TODO: 刪除磁碟中圖片！
                        var oImgs = _context.ArticleTitleImages.Where(i => i.ArticleId == model.ArticleId);
                        if (oImgs != null)
                        {
                            foreach (var img in oImgs)
                            {
                                _context.ArticleTitleImages.Remove(img);
                                var fpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "ckeditor", img.PicturePath);
                                //var fpath = Path.Combine(_env.WebRootPath, img.PicturePath);
                                if (System.IO.File.Exists(fpath))
                                {
                                    System.IO.File.Delete(fpath);
                                }
                            }
                        }

                        var oldImgs = _context.ArticleContentImages.Where(i => i.ArticleId == model.ArticleId);
                        if (oldImgs != null)
                        {
                            foreach (var img in oldImgs)
                            {
                                _context.ArticleContentImages.Remove(img);

                                var fpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "ckeditor", img.PicturePath);
                                if (System.IO.File.Exists(fpath))
                                {
                                    System.IO.File.Delete(fpath);
                                }
                            }
                        }

                        int cnt = 0;    // 跳過前五筆來自 FormData 的紀錄(ArticleId, MemberId, Title, CategoryId, Content)
                        foreach (var key in model.Images.Keys)
                        {
                            var fileName = "";
                            if (cnt > 4 && key.StartsWith("Images[0]"))
                            {
                                // 使用第一張圖做部落格文章 titile image
                                fileName = model.Images[key];

                                article.ArticleTitleImage.PicturePath = fileName;
                            }
                            else if (cnt > 5 && key.StartsWith("Images["))
                            {
                                // 其餘圖片為內文圖片
                                if (article.ArticleContentImages.Any(i => i.PicturePath != model.Images[key]))
                                    article.ArticleContentImages
                                        .Add(new ArticleContentImage
                                        {
                                            PicturePath = model.Images[key]
                                        });
                            }
                            cnt++;
                        }
                    }

                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(model.ArticleId))
                    {
                        return Results.NotFound(new { Status = false, Message = "文章不存在，無法更新" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return Results.Ok(new { Status = true, Message = "文章修改，更新成功" });
            }
            return Results.NotFound(new { Status = true, Message = "請再試一次！" });
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }

        /// <summary>
        /// 刪除部落格文章
        /// </summary>
        /// <param name="ArticleId">文章 ID</param>
        /// <returns></returns>
        [Authorize]
        [ActionName("Delete")]
        public async Task<IResult> DeleteConfirmed(int ArticleId)
        {
            if (await _context.Articles
                .Include(a => a.ArticleTitleImage)
                .Include(a => a.ArticleContentImages)
                .FirstOrDefaultAsync(a => a.Id == ArticleId) is Article article)
            {
                // TODO 需要同一名作者才可刪文
                // ...

                // 移除影像檔    TODO: 刪除磁碟中圖片！
                if (article.ArticleTitleImage != null)
                {
                    var tImg = article.ArticleTitleImage;
                    if (tImg != null)
                        _context.ArticleTitleImages.Remove(tImg);
                }

                if (article.ArticleContentImages != null)
                {
                    foreach (var cimg in article.ArticleContentImages)
                    {
                        var fileName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "ckeditor", cimg.PicturePath);
                        //var fileName = Path.Combine(_env.WebRootPath, cimg.PicturePath);
                        var f2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "ckeditor", cimg.PicturePath);
                        var AreTheSame = System.IO.FileInfo.ReferenceEquals(fileName, f2);

                        if (AreTheSame && System.IO.File.Exists(fileName))
                            System.IO.File.Delete(fileName);

                        if (AreTheSame && System.IO.File.Exists(f2))
                            System.IO.File.Delete(f2);

                        article.ArticleContentImages.Remove(cimg);
                    }
                }

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
        /// CK Editor 上傳圖片用
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public async Task<MsgBlogUploadImageModel> UploadImage([FromForm] IFormCollection images)
        //public async Task<IResult> UploadImage([FromForm] IFormFile image)
        {
            if (images == null || images.Count <= 0)
                return new MsgBlogUploadImageModel
                {   // 此為指定的特定回傳格式，知會 CKFinder 圖片上傳狀況
                    Uploaded = false,
                    FileName = "",
                    Url = ""
                };

            //var rootPath = $@"{_env.WebRootPath}\images\ckeditor";
            var rootPath = $@"/images/ckeditor";
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            string filePath = "";
            string fileName = "";
            foreach (var image in images.Files)
            {
                fileName = $"{DateTime.UtcNow.Ticks}_ck{ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"')}";
                //fileName = Path.GetFileName(image.FileName);
                if (string.IsNullOrEmpty(fileName))
                    return new MsgBlogUploadImageModel
                    {
                        Uploaded = false,
                        FileName = "",
                        Url = ""
                    };

                //filePath = Path.Combine(rootPath, fileName);
                filePath = Path.Combine(
                   Directory.GetCurrentDirectory(), "wwwroot/images", "ckeditor", fileName);

                using (var stream = new MemoryStream())
                {
                    await image.CopyToAsync(stream);
                    stream.Position = 0;
                    using (ImageMagick.MagickImage img = new ImageMagick.MagickImage(stream))
                    {
                        img.Resize(new MagickGeometry(320, 270));
                        //    size.IgnoreAspectRatio = true;

                        using (FileStream outputStream = new FileStream(filePath, FileMode.Create))
                        {
                            img.Write(outputStream);
                        }
                    }
                }
            }

            var url = $"{"/images/ckeditor/"}{fileName}";

            return new MsgBlogUploadImageModel
            {
                Uploaded = true,
                FileName = $"{fileName}",
                Url = url
            };
        }
    }
}