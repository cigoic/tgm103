using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/size/[action]")]
    [ApiController]
    public class SizeApiController : ControllerBase
    {
        private readonly ShopContext _context;
        public SizeApiController(ShopContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<SizeApiModel> GetAll()
        {
            return Enum.GetValues(typeof(Size))
               .Cast<Size>().Select(x => new SizeApiModel
               {
                   Id = (int)x,
                   Type = x.GetDescriptionText()
               }).ToList();
        }
    }
}
