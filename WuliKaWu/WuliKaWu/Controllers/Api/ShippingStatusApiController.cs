using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/shippingstatus/[action]")]
    [ApiController]
    public class ShippingStatusApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public ShippingStatusApiController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ShippingStatusViewModel> GetAll()
        {
            return Enum.GetValues(typeof(ShippingStatus))
                .Cast<ShippingStatus>().Select(x => new ShippingStatusViewModel
                {
                    Id = (int)x,
                    Type = x.GetDescriptionText()
                }).ToList();
        }
    }
}