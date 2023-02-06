using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/Color/[action]")]
    public class ColorApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public ColorApiController(ShopContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<ColorApiModel> GetAll()
        {
            return _context.Colors.Select(x => new ColorApiModel
            {
                Id = x.Id,
                Type = x.Type
            }).ToList();
        }
    }
}
