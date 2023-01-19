<<<<<<< HEAD
<<<<<<< HEAD
=======
﻿using Microsoft.AspNetCore.Http;
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
            return _db.Products.Select(x=> new ProductModel{ 
                ProductName= x.ProductName,
                Color= x.Color,
                ImagePath  = "~/assets/images/product/product-5.png",
                Price= x.Price,
                ProductId= x.ProductId,
                Size= x.Size,
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? ""
            }).ToList();
        }
    }
}
<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
>>>>>>> Productvue (#6)
