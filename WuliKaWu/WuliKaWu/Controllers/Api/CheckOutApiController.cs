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
            return _db.OrderDetails.Select(x => new CheckOutModel
            {
                ShippingAddress = x.ShippingAddress,
                Recipient = x.Recipient,
                ContactPhone = x.ContactPhone,
                PicturePath = "~/assets/images/cart/cart-2.jpg",
                ProductName = x.ProductName,
                Color = x.Color,
                Quantity = x.Quantity,
                Size = x.Size,
                Price = x.Price,
                SellingPrice = x.SellingPrice.ToString() ?? "",
                Type = x.Type,
                Coupon = x.Coupon
            }).ToList();
        }
    }
}