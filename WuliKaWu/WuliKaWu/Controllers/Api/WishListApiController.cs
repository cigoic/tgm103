using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/wishlist/[action]")]
    [ApiController]
    public class WishListApiController : ControllerBase
    {
        private readonly ShopContext _db;

        public WishListApiController(ShopContext context)
        {
            _db = context;
        }

        public List<WishListModel> GetAll()
        {
            return _db.WishList.Select(x => new WishListModel
            {
                WishListId = x.WishListId,
                ProductName = x.ProductName,
                Price = x.Price,
                SellingPrice = x.SellingPrice,
                Discount = x.Discount,
                Picture = x.Picture,
            }).ToList();
        }
    }
}