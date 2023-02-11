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
    }
}