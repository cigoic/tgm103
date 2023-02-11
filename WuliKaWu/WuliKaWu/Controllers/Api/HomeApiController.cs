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
        /// <returns></returns>
        public IResult GetNewItems(int topN = 8)
        {
            return _context.Products
                //.Include(x => x.Colors)
                .Include(x => x.Pictures)
                //.Include(x => x.Tags)
                .OrderByDescending(p => p.ProductId)
                .Take(topN)
                .Select(p => new HomeNewProductsModel
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    SellingPrice = p.SellingPrice,
                    Discount = p.SellingPrice.HasValue ? true : false,
                    Pictures = p.Pictures.Select(p => p.PicturePath),
                })
                is IEnumerable<HomeNewProductsModel> products
                ? Results.Ok(products)
                : Results.NoContent();
        }

        /// <summary>
        /// 首頁 - 取得評價最高的商品 (Top N)
        /// </summary>
        /// <returns></returns>
        public IResult GetTopNItems(int topN = 8)
        {
            return _context.StarRate
                .Include(s => s.Product)
                .Where(s => s.Type >= Data.Enums.Common.StarRateEnum.FourStar)
                .OrderByDescending(s => s.Type)
                .Select(s => s.Product)
                .Take(topN)
                .Select(p => new HomeTopNProductsModel
                {
                    Id = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    SellingPrice = p.SellingPrice,
                    Discount = p.SellingPrice.HasValue ? true : false,
                    Pictures = p.Pictures.Select(p => p.PicturePath),
                })
                is IEnumerable<HomeTopNProductsModel> products
                ? Results.Ok(products)
                : Results.NoContent();
        }
    }
}