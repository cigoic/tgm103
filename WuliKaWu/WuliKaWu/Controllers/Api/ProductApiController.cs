<<<<<<< HEAD
<<<<<<< HEAD
=======
嚜簑sing Microsoft.AspNetCore.Http;
=======
using Microsoft.AspNetCore.Http;
>>>>>>> Productvue (#6)
using Microsoft.AspNetCore.Mvc;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/product/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ShopContext _db;

        public ProductApiController(ShopContext context)
        {
            _db = context;
        }

        public List<ProductModel> GetAll()
        {
            return _db.Products.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                Color = x.Color,
                ImagePath = "~/assets/images/product/product-5.png",
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size,
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO 為什麼要轉型
                Tag = (Data.Enums.Common.Tag)x.Tag
            }).ToList();
        }
    }
}
<<<<<<< HEAD
>>>>>>> [��湔�財 鞈����摨怨�����銵�
=======
>>>>>>> Productvue (#6)
