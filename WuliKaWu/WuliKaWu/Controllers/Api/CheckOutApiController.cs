using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/checkout/[action]")]
    [ApiController]
    public class CheckOutApiController : ControllerBase
    {
        private readonly ShopContext _db;

        public CheckOutApiController(ShopContext context)
        {
            _db = context;
        }

        public List<CheckOutModel> GetAll()
        {
            return _db.Carts.Select(x => new CheckOutModel
            {
                PicturePath = "~/assets/images/cart/cart-2.jpg",
                ProductName = x.ProductName,
                Color = x.Color,
                Quantity = x.Quantity,
                Size = x.Size,
                Price = x.Price,
                SellingPrice = x.SellingPrice.ToString() ?? "",
                Coupon = x.Coupon,
                Type = (Data.Enums.Common.GetPayType)2,
                ShippingAddress = "台北市中山區南京西路1號",
                Recipient = "胖虎",
                ContactPhone = "0900 123 456"
            }).ToList();
        }
    }
}