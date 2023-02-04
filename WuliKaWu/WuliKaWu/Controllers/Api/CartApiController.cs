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

        public List<CartModel> GetAll()
        {
            return _context.Carts.Select(x => new CartModel
            {
                CartId = x.CartId,
                Product = x.Product
            }).ToList();
        }

        //TODO Get一個會員的購物車的所有商品
        [HttpGet]
        public async Task<IEnumerable<CartModel>> GetCart()
        {
            var myId = User.Claims.GetMemberId();

            if (myId == null)
            {
                return Enumerable.Empty<CartModel>(); //TODO
            }

            var cart = (await _context.Carts
                .Where(c => c.MemberId == myId)
                .Select(c => new CartModel
                {
                    CartId = c.MemberId,
                    Product = c.Product,
                }
                )
                .ToListAsync());

            return cart;
        }
    }
}