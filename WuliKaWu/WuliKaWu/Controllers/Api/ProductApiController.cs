using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        /// 取得所有商品
        /// </summary>
        /// <returns></returns>

        public List<ProductModel> GetAll()
        {
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
        }

        /// <summary>
        /// 取得對應id的商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public PreviewModel GetById(int id)
        {
            throw new NotImplementedException();
            //var data = _context.Products.FirstOrDefault(x => x.ProductId == id);

            //if (data == null)
            //{
            //    return null;
            //}
            //var model = new PreviewModel
            //{
            //    ProductId = data.ProductId,
            //    PicturePath = data.PicturePath,
            //    ProductName = data.ProductName,
            //    Color = data.Color,
            //    Size = data.Size.GetDescriptionText(),
            //    Price = data.Price,
            //    Discount = data.Discount.HasValue ? data.Discount.Value > 0 ? true : false : false,
            //    SellingPrice = data.SellingPrice.HasValue ? data.SellingPrice.Value.ToString() : "",
            //    Category = (Category)data.CategoryId,
            //    Tag = (Tag)data.Tag
            //};

            //return model;
        }

        /// <summary>
        /// 編輯對應id的商品
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
        /// 新增商品至資料庫
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
                Colors = data.ColorIds.Select(x => new Data.Color { Id = x }).ToList(),
                Tags = data.TagIds.Select(x => new Data.Tag { Id = x }).ToList(),
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
}