using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
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
        private readonly ShopContext _context;

        public WishListApiController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<WishListModel>> GetAll()
        {
            return await _context.WishList.Select(x => new WishListModel
            {
                WishListId = x.WishListId,
                ProductName = x.Product.ProductName,
                Price = x.Product.Price,
                SellingPrice = (decimal)x.Product.SellingPrice,
                Discount = (decimal)x.Product.Discount,
                PicturePath = x.Product.PicturePath,
                ProductId = x.ProductId,
                MemberId = x.MemberId
            }).ToListAsync();
        }

        //TODO Get一個會員的收藏清單
        [HttpGet("{id}")]
        public async Task<IEnumerable<WishListModel>> GetWishList(int productId)
        {
            var myId = User.Claims.GetMemberId();
            return (await _context.WishList
                .Where(w => w.ProductId == productId && w.MemberId == myId)
                .Select(w => new WishListModel
                {
                    WishListId = w.WishListId,
                    ProductName = w.Product.ProductName,
                    Price = w.Product.Price,
                    SellingPrice = (decimal)w.Product.SellingPrice,
                    Discount = (decimal)w.Product.Discount,
                    PicturePath = w.Product.PicturePath,
                    ProductId = w.ProductId,
                    MemberId = w.MemberId
                }
                )
                .ToListAsync());
        }

        //TODO AddtoCart(右邊Button)
        //[HttpPost("{id}")]
        //[Authorize]

        //TODO 寫在商品頁面的收藏清單(Productapicontroller)
        //[Authorize]
        //[HttpPost("{id}")]
        //public bool AddWishList(int productId)
        //{
        //    var myId = User.Claims.GetMemberId();
        //    var wishItem = _context.WishList.FirstOrDefault(x => x.MemberId == myId && x.ProductId == productId);
        //    var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
        //    if (wishItem == null)
        //    {
        //        _context.WishList.Add(new WishList
        //        {
        //            ProductId = productId,
        //            MemberId = myId,
        //        });
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
    }
}