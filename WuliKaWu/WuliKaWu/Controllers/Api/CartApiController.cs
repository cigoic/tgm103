using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/cart/[action]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly ShopContext _db;

        public CartApiController(ShopContext context)
        {
            _db = context;
        }

        public List<CartModel> GetAll()
        {
            return _db.Carts.Select(x => new CartModel
            {
                CartId = x.CartId,
                Color = x.Color,
                Coupon = x.Coupon,
                ImagePath = "/img/pic01.jpg",
                Price = x.Price,
                ProductName = x.ProductName,
                Quantity = x.Quantity,
                SellingPrice = x.SellingPrice,
                Size = x.Size
            }).ToList();
        }
    }
}