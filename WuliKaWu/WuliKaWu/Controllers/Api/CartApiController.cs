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

        //TODO 移除購物車的商品
        //[HttpPost("{cartId}")]
        //public async Task<IActionResult> RemoveToCart(int cartId)
        //{
        //    if (_context.Carts == null)
        //    {
        //        return Problem("Entity set 'ShopContext.Cart' is null.");
        //    }

        //    var cart = await _context.Members.FindAsync(cartId);

        //    if (cart != null)
        //    {
        //        //var cartproduct = cart.Cart.Product;
        //        //_context.Carts.Remove(cartproduct)
        //        //cart.Cart.ProductId.Remove();
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}