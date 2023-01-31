using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
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
                PicturePath = x.PicturePath,
                ProductId = x.ProductId,
                MemberId = x.MemberId
            }).ToList();
        }

        [Authorize]
        public bool AddWishList(int productId)
        {
            var myId = User.Claims.GetMemberId();
            var wishItem = _db.WishList.FirstOrDefault(x => x.MemberId == myId && x.ProductId == productId);
            var product = _db.Products.FirstOrDefault(x => x.ProductId == productId);
            if (wishItem == null)
            {
                _db.WishList.Add(new WishList
                {
                    ProductId = productId,
                    MemberId = myId,
                });
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}