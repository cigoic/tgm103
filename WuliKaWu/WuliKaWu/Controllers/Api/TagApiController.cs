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
<<<<<<< HEAD
            return _context.Tags.Select(x => new TagApiModel
=======
            return _context.Colors.Select(x => new TagApiModel
>>>>>>> [修正]商品新增
            {
                Id = x.Id,
                Type = x.Type
            }).ToList();
        }
    }
}
