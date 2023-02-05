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

        /// <summary>
        /// Get全部會員的所有收藏清單
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WishListModel>> GetAll()
        {
            var wlist = await _context.WishList.Select(x => new WishListModel
            {
                WishListId = x.WishListId,
                //ProductName = x.Product.ProductName,
                //Price = x.Product.Price,
                //SellingPrice = (decimal)x.Product.SellingPrice,
                //Discount = (decimal)x.Product.Discount,
                //PicturePath = x.Product.PicturePath,
                ProductId = x.ProductId,
                MemberId = x.MemberId
            }).ToListAsync();

            return wlist;
        }

        /// <summary>
        /// 商品頁面加入"收藏清單"
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{productId}")]
        public async Task<ApiResultModel> AddWishListAsync(int productId)
        {
            try
            {
                var myId = User.Claims.GetMemberId();
                var wishItem = await _context.WishList.FirstOrDefaultAsync(x => x.MemberId == myId && x.ProductId == productId);
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (wishItem == null)
                {
                    _context.WishList.Add(new WishList
                    {
                        ProductId = productId,
                        MemberId = myId,
                    });

                    await _context.SaveChangesAsync();

                    return new ApiResultModel
                    {
                        Status = true,
                        Message = "加入成功"
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return new ApiResultModel
            {
                Status = false,
                Message = "已放入收藏清單"
            };
        }

        /// <summary>
        /// Get一個會員的所有收藏清單
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WishListModel>> GetWishListAsync()
        {
            var myId = User.Claims.GetMemberId();
            return (await _context.WishList
                .Where(x => x.MemberId == myId)
                .Select(x => new WishListModel
                {
                    WishListId = x.WishListId,
                    ProductId = x.ProductId,
                    MemberId = x.MemberId,
                    //Price = x.Product.Price,
                    //SellingPrice = (decimal)x.Product.SellingPrice,
                    //Discount = (decimal)x.Product.Discount,
                    //PicturePath = x.Product.PicturePath,
                }).ToListAsync());
        }

        //TODO 加入購物車 AddtoCart(右邊Button)
        [HttpPost("{productId}")]
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
                    //Product = product
                });
                //TODO 彈跳提醒sweetalert
                await _context.SaveChangesAsync();
                return "已加入購物車";
            }
            return "已有此商品";
        }

        //TODO 移除收藏清單的商品 RemoveToWishlist

        [HttpPost("{wishlistId}")]
        public async Task<IActionResult> RemoveToWishlist(int wishlistId)
        {
            if (_context.WishList == null)
            {
                return Problem("Entity set 'ShopContext.Wishlist' is null.");
            }

            var wishlist = await _context.Members.FindAsync(wishlistId);
            //var item = _context.WishList.Where(w => w.ProductId != wishlist.WishList.ProductId); //wishlist.WishList.ProductId).Product;

            //if (wishlist != null && item != null)
            //{
            //    wishlist.WishList = (WishList?)item;
            //}

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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