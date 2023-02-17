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
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IEnumerable<OrderApiModel>> GetOrderAsync(int id)
        {
            var myId = User.Claims.GetMemberId();
            var data = _context.Orders.Include(x => x.Status).FirstOrDefault(x => x.OrderId == id);

            if (data == null)
            {
                return null;
            }

            try
            {
                var order = _context.Orders
                    .Where(o => o.MemberId == myId)
                    .Select(o => new OrderApiModel
                    {
                        MemberId = myId,
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate.ToString("F"),
                        ShippingDate = o.ShippingDate.ToString("F"),
                        StatusId = o.OrderId,
                        StatusType = o.Status.GetDescriptionText(),
                        GetPayType = o.Type.GetDescriptionText(),
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

        public IResult GetOrders()
        {
            var myId = User.Claims.GetMemberId();
            var orders = _context.Orders.Where(o => o.MemberId == myId)
                .Select(o => new OrderApiModel
                {
                    MemberId = myId,
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate.ToString("F"),
                    ShippingDate = o.ShippingDate.ToString("F"),
                    StatusId = o.OrderId,
                    StatusType = o.Status.GetDescriptionText(),
                    GetPayTypeId = o.OrderId,
                    GetPayType = o.Type.GetDescriptionText(),
                    Recipient = o.Recipient,
                    ShippingAddress = o.ShippingAddress,
                    ContactPhone = o.ContactPhone,
                    Memo = o.Memo
                });

            return Results.Ok(orders);
        }
    }
}