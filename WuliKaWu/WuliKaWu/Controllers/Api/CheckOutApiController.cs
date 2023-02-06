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
        private readonly ShopContext _context;

        public CheckOutApiController(ShopContext context)
        {
            _context = context;
        }

        public List<CheckOutModel> GetAll()
        {
            throw new NotImplementedException();
            //return _context.Carts.Select(x => new CheckOutModel
            //{
            //    CheckOutId = 2,
            //    PicturePath = "/assets/images/cart/cart-2.jpg",
            //    ProductName = x.Product.ProductName,
            //    Colors = x.Product.Colors.Select(x=> x.Type).ToList(),
            //    Quantity = x.Quantity,
            //    Size = x.Product.Size,
            //    Price = x.Product.Price,
            //    SellingPrice = x.Product.SellingPrice.ToString() ?? "",
            //    //Coupon = x.Product.Coupon,
            //    Type = (Data.Enums.Common.GetPayType)2,
            //    ShippingAddress = "台北市中山區南京西路1號",
            //    Recipient = "胖虎",
            //    ContactPhone = "0900 123 456"
            //}).ToList();

        }
    }
}