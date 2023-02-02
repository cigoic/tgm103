<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
=======
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
>>>>>>> 新增CartController及CartApiController
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/cart/[action]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private readonly ShopContext _context;

        public CartApiController(ShopContext context)
        {
            _context = context;
        }

        //public List<CartModel> GetAll()
        //{
        //    return _context.Carts.Select(x => new CartModel
        //    {
        //        CartId = x.CartId,
        //        Product = x.Product
        //    }).ToList();
        //}

        /// <summary>
        /// 商品頁面加入"購物車"
        /// </summary>
        /// <param name="WishListId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{productId}")]
        public async Task<ApiResultModel> AddToCartAsync(int productId)
        {
            try
            {
                var myId = User.Claims.GetMemberId();
                var cartItem = await _context.Carts.FirstOrDefaultAsync(x => x.MemberId == myId && x.ProductId == productId);
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (cartItem == null)
                {
                    _context.Carts.Add(new Cart
                    {
                        MemberId = myId,
                        ProductId = productId,
                        Quantity = 1,
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
                Message = "已收入購物車"
            };
        }

        //TODO Get一個會員的所有購物車
        /// <summary>
        /// Get一個會員的所有購物車
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CartGetModel>> GetCartAsync()
        {
            var myId = User.Claims.GetMemberId();
            return (await _context.Carts
                .Where(c => c.MemberId == myId)
                .Select(c => new CartGetModel
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    MemberId = c.MemberId,
                    ProductName = c.Product.FirstOrDefault(p => p.ProductId == c.ProductId).ProductName,
                    Price = c.Product.FirstOrDefault(p => p.ProductId == c.ProductId).Price,
                    SellingPrice = (decimal)c.Product.FirstOrDefault(p => p.ProductId == c.ProductId).SellingPrice,
                    //PicturePath = c.Product.FirstOrDefault(p=> p.ProductId == c.ProductId)
                }).ToListAsync());
        }

        //TODO 移除購物車的商品
        [HttpPost("{cartId}")]
        public async Task<IActionResult> RemoveToCart(int cartId)
        {
            if (_context.Carts == null)
            {
                return Problem("Entity set 'ShopContext.Cart' is null.");
            }

            var cart = await _context.Members.FindAsync(cartId);

            if (cart != null)
            {
                //var cartproduct = cart.Cart.Product;
                //_context.Carts.Remove(cartproduct)
                //cart.Cart.ProductId.Remove();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
=======
        private readonly ShopContext _db;
=======
        private readonly ShopContext _context;
>>>>>>> [新增]AddWishList Action 及 AddToCart Action

        public CartApiController(ShopContext context)
        {
            _context = context;
        }

        public List<CartModel> GetAll()
        {
            return _context.Carts.Select(x => new CartModel
            {
                CartId = x.CartId,
                Color = x.Color,
                Coupon = x.Coupon,
                PicturePath = "~/assets/images/cart/cart-2.jpg",
                Price = x.Price,
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                SellingPrice = x.SellingPrice.ToString() ?? "",
<<<<<<< HEAD
                Size = x.Size
=======
                Size = x.Size,
                //TODO Total(要寫嗎?)
>>>>>>> 新增ShopContext Entity的Cart及Wishlist,新增Vue2 dev version及production,調整Cartapicontroller版面
            }).ToList();
>>>>>>> 新增CartController及CartApiController
        }
    }
}