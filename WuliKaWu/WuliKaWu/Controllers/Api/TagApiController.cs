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
<<<<<<< HEAD
            return _context.Tags.Select(x => new TagApiModel
=======
            return _context.Colors.Select(x => new TagApiModel
>>>>>>> [修正]商品新增
=======
            return _context.Tags.Select(x => new TagApiModel
>>>>>>> fix product index filter tag and size
            {
                Id = x.Id,
                Type = x.Type
            }).ToList();
        }

        [HttpGet]
        public TagApiModel GetById (int id) 
        {
            var data = _context.Tags.FirstOrDefault(x => x.Id == id);

            if (data == null) return null;
            var model = new TagApiModel
            {
                Id = data.Id,
                Type = data.Type
            };
            return model;
        }
    }
}
