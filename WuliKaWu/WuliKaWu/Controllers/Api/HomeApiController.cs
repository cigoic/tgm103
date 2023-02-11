using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/Home/[action]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public HomeApiController(ShopContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 首頁 - 取得最新上架的商品
        /// </summary>
        /// <param name="topN">取回紀錄筆數</param>
        /// <returns></returns>
        public IResult GetNewItems(int topN = 8)
        {
            return _context.Products
                .Include(x => x.Pictures)
                .OrderByDescending(p => p.ProductId)
                .Take(topN)
                .Select(p => new HomeNewItemsModel
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    SellingPrice = p.SellingPrice,
                    Discount = p.SellingPrice.HasValue ? true : false,
                    Pictures = p.Pictures.Select(p => p.PicturePath),
                })
                is IEnumerable<HomeNewItemsModel> products
                ? Results.Ok(products)
                : Results.NoContent();
        }

        /// <summary>
        /// 首頁 - 取得評價最高的商品 (Top N)
        /// </summary>
        /// <param name="topN">取回紀錄筆數</param>
        /// <returns></returns>
        public IResult GetTopNItems(int topN = 8)
        {
            return _context.StarRate
                .Include(s => s.Product)
                .Where(s => s.Type >= Data.Enums.Common.StarRateEnum.FourStar)
                .OrderByDescending(s => s.Type)
                .Select(s => s.Product)
                .Take(topN)
                .Select(p => new HomeTopNItemsModel
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    SellingPrice = p.SellingPrice,
                    Discount = p.SellingPrice.HasValue ? true : false,
                    Pictures = p.Pictures.Select(p => p.PicturePath),
                })
                is IEnumerable<HomeTopNItemsModel> products
                ? Results.Ok(products)
                : Results.NoContent();
        }

        /// <summary>
        /// 首頁 - 取得正在促銷的商品
        /// </summary>
        /// <param name="topN">取回紀錄筆數</param>
        /// <returns></returns>
        public IResult GetSaleItems(int topN = 8)
        {
            return _context.Products
                .Include(x => x.Pictures)
                .OrderByDescending(p => p.Price - p.SellingPrice)
                .Take(topN)
                .Select(p => new HomeSaleItemsModel
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    SellingPrice = p.SellingPrice,
                    Discount = p.SellingPrice.HasValue ? true : false,
                    Pictures = p.Pictures.Select(p => p.PicturePath),
                })
                is IEnumerable<HomeSaleItemsModel> products
                ? Results.Ok(products)
                : Results.NoContent();
        }

        /// <summary>
        /// 取回最新文章列表
        /// </summary>
        /// <param name="numberOfArticles">要取回的文章篇數</param>
        /// <returns></returns>
        public IResult GetLastestPost(int numberOfArticles = 3)
        {
            return _context.Articles
                .Include(a => a.ArticleCategory)
                .OrderByDescending(a => a.CreatedDate)
                .Take(numberOfArticles)
                .Select(a => new HomeLastestPostModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    CreatedDate = a.CreatedDate,
                    MemberName = _context.Members.FirstOrDefault(m => m.MemberId == a.MemberId).Name,
                    Category = a.ArticleCategory.Type
                })
                is IEnumerable<HomeLastestPostModel> articles
                ? Results.Ok(articles)
                : Results.NotFound(new { Status = false, Message = "無法取回最新文章列表" });
        }
    }
}