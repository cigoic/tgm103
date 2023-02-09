using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/picture/[action]")]
    [ApiController]
    public class PicturesApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public PicturesApiController(ShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<PictureApiModel> GetAll()
        {
            return _context.Pictures.Select(x => new PictureApiModel
            {
                PictureId = x.PictureId,
                PicturePath = x.PicturePath
            }).ToList();
        }
    }
}