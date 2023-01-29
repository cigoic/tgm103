<<<<<<< HEAD
<<<<<<< HEAD
=======
﻿using Microsoft.AspNetCore.Http;
=======
using Microsoft.AspNetCore.Http;
>>>>>>> Productvue (#6)
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/product/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductApiController(ShopContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetAll()
        {
<<<<<<< HEAD
            return _db.Products.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                Color = x.Color,
                ImagePath = "~/assets/images/product/product-5.png",
=======
            return _context.Products.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                Color = x.Color,
<<<<<<< HEAD
<<<<<<< HEAD
                PicturePath = "~/assets/images/product/product-5.png",
>>>>>>> [修正]商品編輯檢視頁面的儲存編輯按鈕連動
=======
                PicturePath = x.PicturePath,
>>>>>>> [更新]ProductApiController 的 GetById方法
=======
                PicturePath = $"~/images/{productModel.PicturePath}",
>>>>>>> [更新] ProductApiController圖片路徑更新
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size,
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO ������n�૬
                Tag = (Data.Enums.Common.Tag)x.Tag
            }).ToList();
        }

        public ProductModel GetById(int id, ProductModel productModel)
        {
            if (id != productModel.ProductId)
            {
                return null;
            }

            Product product = _context.Products.Find(productModel.ProductId);
            product.ProductName = productModel.ProductName;
            product.Color = productModel.Color;
            product.Size = productModel.Size;
            product.Category = productModel.Category;
            product.PicturePath = $"~/images/{productModel.PicturePath}";
            product.Price = productModel.Price;
            product.Discount = Convert.ToDecimal(productModel.Discount);
            product.SellingPrice = decimal.Parse(productModel.SellingPrice);

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return productModel;
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }
    }
}
<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
>>>>>>> Productvue (#6)
