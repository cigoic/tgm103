using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/Category/[action]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public CategoriesApiController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/CategoriesApi
        [HttpGet]
        public List<CategoryApiModel> GetAll()
        {
            return _context.Categories.Select(x=> new CategoryApiModel { 
                Id = x.CategoryId,
                Type = x.Type
            }).ToList();
        }
    }
}
