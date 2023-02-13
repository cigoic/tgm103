using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/order/[action]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public OrderApiController(ShopContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 會員的訂單
        /// </summary>
        /// <param name="checkoutId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<OrderApiModel>> GetOrderAsync()
        {
            var myId = User.Claims.GetMemberId();
            try
            {
                var order = _context.Orders
                    .Where(o => o.MemberId == myId )
                    .Select(o => new OrderApiModel
                    {
                        MemberId = myId,
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        ShippingDate = o.ShippingDate,
                        Status = o.Status,
                        Type = o.Type,
                        Recipient = o.Recipient,
                        ShippingAddress = o.ShippingAddress,
                        ContactPhone = o.ContactPhone,
                        Memo = o.Memo
                    });
                return await order.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}