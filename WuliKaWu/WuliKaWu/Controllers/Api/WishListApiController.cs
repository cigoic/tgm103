<<<<<<< HEAD
<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
=======
﻿using Microsoft.AspNetCore.Http;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
>>>>>>> [新增]AddWishList Action
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WuliKaWu.Data;
<<<<<<< HEAD
>>>>>>> 新增WishListTable及Api
=======
using WuliKaWu.Extensions;
>>>>>>> [新增]AddWishList Action
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/wishlist/[action]")]
    [ApiController]
    public class WishListApiController : ControllerBase
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private readonly ShopContext _context;

        public WishListApiController(ShopContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
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
                //TODO PicturePath尚未確定
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

                //if (wishItem == null && product != null && myId > 0)
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
        public async Task<IEnumerable<WishListGetModel>> GetWishListAsync(int productId)
        {
            //throw new NotImplementedException();

            var myId = User.Claims.GetMemberId();

            return (await _context.WishList.Include(x => x.Product)
                .Where(x => x.MemberId == myId)
                .Select(x => new WishListGetModel
                {
                    WishListId = x.WishListId,
                    ProductName = x.Product.ProductName,
                    Price = x.Product.Price,
                    SellingPrice = (decimal)x.Product.SellingPrice,
                    Pictures = x.Product.Pictures.Select(x => x.PicturePath).ToList(),
                    ProductId = x.ProductId,
                    MemberId = x.MemberId
                }
                )
                .ToListAsync());
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
=======
        private readonly ShopContext _db;
=======
        private readonly ShopContext _context;
>>>>>>> [新增]AddWishList Action 及 AddToCart Action

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

=======
>>>>>>> [修改]Gettocart及Getwishlist
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
                //TODO PicturePath尚未確定
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

                //if (wishItem == null && product != null && myId > 0)
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
<<<<<<< HEAD
<<<<<<< HEAD
                WishListId = x.WishListId,
                ProductName = x.Product.ProductName,
                Price = x.Product.Price,
                SellingPrice = (decimal)x.Product.SellingPrice,
                Discount = (decimal)x.Product.Discount,
                PicturePath = x.Product.PicturePath,
                ProductId = x.ProductId,
                MemberId = x.MemberId
<<<<<<< HEAD
            }).ToList();
>>>>>>> 新增WishListTable及Api
=======
            }).ToListAsync();
>>>>>>> [新增]AddWishList Action 及 AddToCart Action
        }
=======
                return Enumerable.Empty<WishListModel>();   //TODO
            }
>>>>>>> [新增]AddtToWishList Action
=======
                throw;
            }
            return new ApiResultModel
            {
                Status = false,
                Message = "已放入收藏清單"
            };
        }
>>>>>>> [修改]Gettocart及Getwishlist

        /// <summary>
        /// Get一個會員的所有收藏清單
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<WishListGetModel>> GetWishListAsync(int productId)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var myId = User.Claims.GetMemberId();
            return (await _context.WishList
                .Where(x => x.MemberId == myId)
                .Select(x => new WishListModel
                {
<<<<<<< HEAD
                    WishListId = w.WishListId,
                    ProductName = w.Product.ProductName,
                    Price = w.Product.Price,
                    SellingPrice = (decimal)w.Product.SellingPrice,
                    PicturePath = w.Product.Pictures.FirstOrDefault().PicturePath,
                    ProductId = w.ProductId,
                    MemberId = w.MemberId
                }
                )
                .ToListAsync());
=======
                    WishListId = x.WishListId,
                    ProductId = x.ProductId,
                    MemberId = x.MemberId,
                    //Price = x.Product.Price,
                    //SellingPrice = (decimal)x.Product.SellingPrice,
                    //Discount = (decimal)x.Product.Discount,
                    //PicturePath = x.Product.PicturePath,
                }).ToListAsync());
<<<<<<< HEAD

            //var wishItem = _context.WishList.FirstOrDefaultAsync(w => w.MemberId == myId && w.ProductId == productId);
            //var product = _context.Products.FirstOrDefaultAsync(w => w.ProductId == productId);

            //if (wishItem == null)
            //{
            //    return Enumerable.Empty<WishListModel>();   //TODO
            //}

            //return (await _context.WishList
            //    .Where(w => w.MemberId == myId)
            //    .Select(w => new WishListModel
            //    {
            //        WishListId = w.WishListId,
            //        ProductName = w.Product.ProductName,
            //        Price = w.Product.Price,
            //        SellingPrice = (decimal)w.Product.SellingPrice,
            //        Discount = (decimal)w.Product.Discount,
            //        PicturePath = w.Product.PicturePath,
=======
            throw new NotImplementedException();    
            //var myId = User.Claims.GetMemberId();
            //return (await _context.WishList
            //    .Where(x => x.MemberId == myId)
            //    .Select(x => new WishListModel
            //    {
            //        WishListId = x.WishListId,
            //        ProductName = x.Product.ProductName,
            //        Price = x.Product.Price,
            //        SellingPrice = (decimal)w.Product.SellingPrice,
            //        PicturePath = w.Product.Pictures.FirstOrDefault().PicturePath,
>>>>>>> [小精靈]
            //        ProductId = w.ProductId,
            //        MemberId = w.MemberId
            //    }
            //    )
            //    .ToListAsync());
<<<<<<< HEAD
>>>>>>> [修改]Gettocart及Getwishlist
=======
>>>>>>> [修改]Addtocart Action
=======
>>>>>>> [小精靈]
        }
=======
            //throw new NotImplementedException();
>>>>>>> [修改]CartApi及WishListapi的Model

            var myId = User.Claims.GetMemberId();

            return (await _context.WishList.Include(x => x.Product)
                .Where(x => x.MemberId == myId)
                .Select(x => new WishListGetModel
                {
                    WishListId = x.WishListId,
                    ProductName = x.Product.ProductName,
                    Price = x.Product.Price,
                    SellingPrice = (decimal)x.Product.SellingPrice,
                    Pictures = x.Product.Pictures.Select(x => x.PicturePath).ToList(),
                    ProductId = x.ProductId,
                    MemberId = x.MemberId
                }
                )
                .ToListAsync());
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