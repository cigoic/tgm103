using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
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

        /// <summary>
        /// Get一個會員的所有購物車 確認"訂單資訊"
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
                          Discount = c.Product.SellingPrice.HasValue ? true : false,
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

        //[HttpGet]
        //[Authorize]
        //public async Task<IEnumerable>

        /// <summary>
        /// Add 寄送資訊明細
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ApiResultModel> PostCheckOutAsync([FromForm] CheckOutDetailModel model)
        {
            try
            {
                var myId = User.Claims.GetMemberId();
                Order order = new Order
                {
                    MemberId = myId,
                    Recipient = model.Recipient,
                    ContactPhone = model.ContactPhone,
                    ShippingAddress = model.ShippingAddress,
                    Memo = model.Memo,                 
                    //Type = model.GetPayType.GetDescriptionText(),
                    OrderDate = DateTime.UtcNow,
                    ShippingDate = DateTime.UtcNow.AddDays(7),
                    //Status = model.Status,
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return new ApiResultModel
                {
                    Status = true,
                    Message = "Established in order"
                };
            }
            catch (Exception ex)
            {
                throw;
            }

            //if(Status != ture)
            ////return new ApiResultModel
            //{
            //    Status = false,
            //    Message = "Uncomplete"
            //};
        }
    }
}