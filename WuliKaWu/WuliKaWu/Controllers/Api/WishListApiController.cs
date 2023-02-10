﻿using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<WishListGetModel>> GetWishListAsync(int productId)
        {
            var myId = User.Claims.GetMemberId();
            try
            {
                var wish = _context.WishList
                    .Where(x => x.MemberId == myId)
                    .Select(x => new WishListGetModel
                    {
                        ProductId = productId,
                        MemberId = myId,
                        WishListId = x.WishListId,
                        ProductName = x.Product.ProductName,
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
        /// <param name="wishlistId"></param>
        /// <returns></returns>

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
    }
}