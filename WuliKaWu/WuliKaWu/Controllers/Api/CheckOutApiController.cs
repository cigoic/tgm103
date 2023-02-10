using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;
using static WuliKaWu.Data.Enums.Common;

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

        //public List<CheckOutModel> GetAll()
        //{
        //    return _context.Carts.Select(x => new CheckOutModel
        //    {
        //        Id = 2,
        //        PicturePath = x.Product.Pictures.Select(p => p.PicturePath).ToString(),
        //        ProductName = x.Product.ProductName,
        //        Colors = x.Product.Colors.Select(x => x.Type).ToList(),
        //        Quantity = x.Quantity,
        //        Size = x.Product.Size,
        //        Price = x.Product.Price,
        //        SellingPrice = x.Product.SellingPrice.ToString() ?? "",
        //        Coupon = x.Product.Coupon,
        //        Type = (Data.Enums.Common.GetPayType)2,
        //        ShippingAddress = "台北市中山區南京西路1號",
        //        Recipient = "胖虎",
        //        ContactPhone = "0900 123 456"
        //    }).ToList();
        //}

        //TODO Get一個會員的所有購物車 做確認Checkout
        /// <summary>
        /// Get一個會員的所有購物車 做確認Checkout
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<CheckOutModel>> GetCheckOutAsync(int productId)
        {
            var myId = User.Claims.GetMemberId();
            try
            {
                var check = _context.Carts
                      .Where(c => c.MemberId == myId)
                      .Select(c => new CheckOutModel
                      {
                          MemberId = myId,
                          ProductId = productId,
                          Id = c.Id,
                          PicturePath = c.Product.Pictures.Select(c => c.PicturePath).ToList(),
                          ProductName = c.Product.ProductName,
                          Type = c.Product.Colors.Select(c => c.Type).ToList(),
                          Quantity = c.Quantity,
                          Size = c.Product.Size.GetDescriptionText(),
                          Price = c.Product.Price,
                          SellingPrice = c.Product.SellingPrice
                      });
                return await check.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}