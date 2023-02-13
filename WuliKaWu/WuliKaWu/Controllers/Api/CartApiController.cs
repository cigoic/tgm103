using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/cart/[action]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
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
                Message = "Product Is Already In Cart!!"
            };
        }

        /// <summary>
        /// Get一個會員的所有購物車
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CartGetModel>> GetCartAsync(int productId)
        {
            var myId = User.Claims.GetMemberId();

            try
            {
                var cart = _context.Carts
                    .Where(c => c.MemberId == myId)
                    .Select(c => new CartGetModel
                    {
                        MemberId = myId,
                        ProductId = c.ProductId,
                        Id = c.Id,
                        ProductName = c.Product.ProductName,
                        Quantity = c.Quantity,
                        PicturePath = c.Product.Pictures.Select(x => x.PicturePath).ToList(),
                        Discount = c.Product.SellingPrice.HasValue ? true : false,
                        Price = c.Product.Price,
                        SellingPrice = c.Product.SellingPrice,
                        Size = c.Product.Size.GetDescriptionText(),
                        Type = c.Product.Colors.Select(x => x.Type).ToList()
                    });
                return await cart.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //TODO 移除購物車的商品 RemoveToCart
        /// <summary>
        /// 移除購物車的商品 RemoveToCart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost("{id}")]
        [Authorize]
        public async Task<ApiResultModel> RemoveToCart([FromBody] Int32 id)
        {
            Cart cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
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