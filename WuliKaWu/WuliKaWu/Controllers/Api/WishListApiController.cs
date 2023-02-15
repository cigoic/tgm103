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
        public async Task<IEnumerable<WishListGetAllModel>> GetAll()
        {
            var wlist = await _context.WishList.Select(x => new WishListGetAllModel
            {
                WishListId = x.WishListId,
                ProductName = x.Product.ProductName,
                Discount = x.Product.SellingPrice.HasValue ? true : false,
                Price = x.Product.Price,
                SellingPrice = (decimal)x.Product.SellingPrice,
                PicturePath = x.Product.Pictures.Select(p => p.PicturePath).ToString(),
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
        [HttpPost]
        public async Task<ApiResultModel> AddWishListAsync([FromBody] int productId)
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
                        Message = "Added Success!!"
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
                Message = "Product Is Already In WishList"
            };
        }

        /// <summary>
        /// Get一個會員的所有收藏清單
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<WishListGetModel>> GetWishListAsync()
        {
            var myId = User.Claims.GetMemberId();
            try
            {
                var wish = _context.WishList
                    .Where(x => x.MemberId == myId)
                    .Select(x => new WishListGetModel
                    {
                        ProductId = x.ProductId,
                        MemberId = myId,
                        WishListId = x.WishListId,
                        ProductName = x.Product.ProductName,
                        Discount = x.Product.SellingPrice.HasValue ? true : false,
                        Price = x.Product.Price,
                        SellingPrice = x.Product.SellingPrice,
                        PicturePath = x.Product.Pictures.Select(x => x.PicturePath).ToList()
                    });
                return await wish.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //TODO 移除收藏清單的商品 RemoveToWishlist
        /// <summary>
        /// 移除收藏清單的商品 RemoveToWishlist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        [Authorize]
        public async Task<ApiResultModel> RemoveToWishlist([FromBody] Int32 id)
        {
            WishList wishList = await _context.WishList.FindAsync(id);
            if (wishList != null)
            {
                _context.WishList.Remove(wishList);
                await _context.SaveChangesAsync();
                return new ApiResultModel
                {
                    Status = true,
                    Message = "Remove Success!"
                };
            }
            return new ApiResultModel
            {
                Status = false,
                Message = "Remove Failed!"
            };
        }
    }
}