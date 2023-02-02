using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/cart/[action]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public CartApiController(ShopContext context)
        {
            _context = context;
        }

        public List<CartModel> GetAll()
        {
            return _context.Carts.Select(x => new CartModel
            {
                CartId = x.CartId,
                Product = x.Product
            }).ToList();
        }
    }
}