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

        //TODO Get全部會員的所有收藏清單
        //[HttpGet]
        //public async Task<IEnumerable<WishListModel>> GetAll()
        //{
        //    var wlist = await _context.WishList.Select(x => new WishListModel
        //    {
        //        WishListId = x.WishListId,
        //        ProductName = x.Product.ProductName,
        //        Price = x.Product.Price,
        //        SellingPrice = (decimal)x.Product.SellingPrice,
        //        Discount = (decimal)x.Product.Discount,
        //        PicturePath = x.Product.PicturePath,
        //        ProductId = x.ProductId,
        //        MemberId = x.MemberId
        //    }).ToListAsync();

        //    return wlist;
        //}


        /// <summary>
        /// Get一個會員的收藏清單的所有商品
        /// </summary>
        /// <returns></returns>       
        [HttpGet]
        public async Task<IEnumerable<WishListModel>> GetWishList()
        {
            var myId = User.Claims.GetMemberId();

            if (myId == null)
            {
                return Enumerable.Empty<WishListModel>();   //TODO
            }

            return (await _context.WishList
                .Where(w => w.MemberId == myId)
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

        //TODO 加入購物車 AddtoCart(右邊Button)
        [HttpPost("{productId}")]
        [ActionName("Login")]
        public async Task<string> AddToCartAsync(int productId)
        {
            var myId = User.Claims.GetMemberId();
            var cart = await _context.WishList.FirstOrDefaultAsync(x => x.MemberId == myId && x.ProductId == productId);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            if (cart == null)
            {
                _context.Carts.Add(new Cart
                {
                    MemberId = myId,
                    ProductId = productId,
                    Quantity = 1,
                    Product = product
                });
                //TODO 彈跳提醒sweetalert
                await _context.SaveChangesAsync();
                return "已加入購物車";
            }
            return "已有此商品";
        }

        //TODO 移除收藏清單

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