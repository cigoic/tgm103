using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/Tag/[action]")]
    [ApiController]
    public class TagApiController : ControllerBase
    {
        private readonly ShopContext _context;
        public TagApiController(ShopContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<TagApiModel> GetAll()
        {
            return _context.Tags.Select(x => new TagApiModel
            {
                Id = x.Id,
                Type = x.Type
            }).ToList();
        }
    }
}
