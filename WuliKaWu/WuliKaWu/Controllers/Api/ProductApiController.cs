<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
﻿using Microsoft.AspNetCore.Http;
=======
=======
using Microsoft.AspNetCore.Authorization;
<<<<<<< HEAD
>>>>>>> [新增]Addtocart Action
=======
using Microsoft.AspNetCore.Hosting;
>>>>>>> [修正]商品新增
using Microsoft.AspNetCore.Http;
>>>>>>> Productvue (#6)
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;
using static NuGet.Packaging.PackagingConstants;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/product/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductApiController(ShopContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        /// <summary>
        /// ���o�Ҧ��ӫ~
        /// </summary>
        /// <returns></returns>

        public List<ProductReadModel> GetAll()
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
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
<<<<<<< HEAD
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
=======
                PicturePath = $"~/images/{x.PicturePath}",
>>>>>>> [更新]ProductApiController的GetAll及GetById的圖片路徑
=======
                PicturePath = x.PicturePath,
>>>>>>> [修正]商品刪除檢視改以vue綁定，在ProductApiController加入GetById方法並新增DeletePreviewModel
=======
                PicturePath = $"/images/{x.PicturePath}",
>>>>>>> [修正] 更動資料表後的 Cart, whishlist 檢視與控制器程式片段
                Price = x.Price,
                ProductId = x.ProductId,
<<<<<<< HEAD
                Size = x.Size,
<<<<<<< HEAD
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO ������n�૬
                Tag = (Data.Enums.Common.Tag)x.Tag
=======
=======
                Size = x.Size.GetDescriptionText(),
>>>>>>> 小精靈的祝福
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
>>>>>>> [修正]ProductApiController的Discount寫死的改掉
            }).ToList();
=======
            throw new NotImplementedException();
            //return _context.Products.Select(x => new ProductModel
            //{
            //    ProductName = x.ProductName,
            //    Color = x.Color,
            //    PicturePath = x.PicturePath,
            //    Price = x.Price,
            //    ProductId = x.ProductId,
            //    Size = x.Size.GetDescriptionText(),
            //    Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
            //    SellingPrice = x.SellingPrice.ToString() ?? ""
            //}).ToList();
>>>>>>> DB修改
=======

            return _context.Products.Include(x=> x.Colors).Include(x=>x.Pictures).Include(x=>x.Tags).Select(x => new ProductReadModel
=======
            return _context.Products.Include(x => x.Colors).Include(x => x.Pictures).Include(x => x.Tags).Select(x => new ProductReadModel
>>>>>>> [修正]刪除不需要的Model以及更改Model名稱
            {
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                Colors = x.Colors.Select(x => x.Id).ToList(),
                Pictures = x.Pictures.Select(x => x.PicturePath).ToList(),
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size,
                Discount = x.SellingPrice.HasValue ? true : false,
                SellingPrice = x.SellingPrice,
                Comment = x.Comment,
                Tags = x.Tags.Select(x => x.Id).ToList()
            }).ToList();
>>>>>>> product index filter-category
        }

        /// <summary>
        /// ���o����id���ӫ~
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ProductPreviewModel GetById(int id)
        {
            var data = _context.Products.Include(x=>x.Pictures).Include(x=>x.Colors).Include(x=>x.Tags).FirstOrDefault(x => x.ProductId == id);

            //return _context.Products.Include(x => x.Colors).Include(x => x.Pictures).Include(x => x.Tags).Where(x => x.ProductId == id).Select(x => new ProductPreviewModel
            //{
            //    ProductId = x.ProductId,
            //    ProductName = x.ProductName,
            //    Colors = x.Colors.Select(x => x.Id).ToList(),
            //    Size = x.Size,
            //    Price = x.Price,
            //    Discount = x.SellingPrice.HasValue ? true : false,
            //    SellingPrice = x.SellingPrice,
            //    CategoryId = x.CategoryId,
            //    Tags = x.Tags.Select(x => x.Id).ToList(),
            //    Pictures = x.Pictures.Select(x => x.PicturePath).ToList()
            //}).Single();

            if (data == null)
            {
                return null;
            }
            var model = new ProductPreviewModel
            {
                ProductId = data.ProductId,
                Pictures = data.Pictures.Select(x => x.PicturePath).ToList(),
                ProductName = data.ProductName,
                Colors = data.Colors.Select(x => x.Id).ToList(),
                Size = data.Size,
                Price = data.Price,
                Discount = data.SellingPrice.HasValue ? true : false,
                SellingPrice = data.SellingPrice,
                CategoryId = data.CategoryId,
                Tags = data.Tags.Select(x => x.Id).ToList()
            };

            return model;
        }

        /// <summary>
        /// �s�����id���ӫ~
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eModel"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public EditModel EditById(int id, EditModel eModel)
        {
            throw new NotImplementedException();
            //Product product = _context.Products.Find(id);
            //product.ProductName = eModel.ProductName;
            //product.Color = eModel.Color;
            //product.Size = (Size)Enum.Parse(typeof(Size), eModel.Size);
            //product.CategoryId = (int)eModel.Category;
            //product.PicturePath = eModel.PicturePath;
            //product.Price = eModel.Price;
            //product.Discount = Convert.ToDecimal(eModel.Discount);
            //product.SellingPrice = decimal.Parse(eModel.SellingPrice);
            //product.Tag = (Tag)eModel.Tag;

            //try
            //{
            //    _context.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductModelExists(id))
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return eModel;
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        /// <summary>
        /// �s�W�ӫ~�ܸ�Ʈw
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public bool AddProduct([FromForm] ProductAddModel data)
        {
            var prd = new Product
            {
                ProductName = data.ProductName,
                Comment = data.Comment,
                CategoryId = data.CategoryId,
                Price = data.Price,
                SellingPrice = data.SellingPrice,
                Size = (Size)data.SizeId,
                Colors = _context.Colors.Where(x => data.ColorIds.Contains(x.Id)).ToList(),
                Tags = _context.Tags.Where(x => data.TagIds.Contains(x.Id)).ToList()
            };

            if (data.Pictures != null)
            {
                var _folder = $@"";
                var picList = new List<Picture>();
                foreach (var file in data.Pictures)
                {
                    if (file.Length > 0)
                    {
                        var path = $@"\images\{DateTime.Now.Ticks}-{file.FileName}";
                        using (var stream = new FileStream($@"{_env.WebRootPath}{path}", FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        picList.Add(new Picture() { PicturePath = path });
                    }
                }
                prd.Pictures = picList;
            }
            _context.Products.Add(prd);
            _context.SaveChanges();
            return true;
        }
    }
}<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
>>>>>>> Productvue (#6)
