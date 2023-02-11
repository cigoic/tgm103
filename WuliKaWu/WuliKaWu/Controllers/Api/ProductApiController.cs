using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Net.NetworkInformation;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;
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
        /// 拿到所有的商品
        /// </summary>
        /// <returns></returns>

        public List<ProductReadModel> GetAll()
        {
            return _context.Products.Include(x => x.Colors).Include(x => x.Pictures).Include(x => x.Tags).Select(x => new ProductReadModel
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
        }

        /// <summary>
        /// 從資料庫拿到對應Id的商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ProductPreviewModel GetById(int id)
        {
            var data = _context.Products.Include(x => x.Category).Include(x => x.Pictures).Include(x => x.Colors).Include(x => x.Tags).FirstOrDefault(x => x.ProductId == id);

            if (data == null)
            {
                return null;
            }
            var tagsViewModel = data.Tags.Select(x => new TagsViewModel
            {
                Id = x.Id,
                Type = x.Type
            }).ToList();

            var colorsViewModel = data.Colors.Select(x => new CorlorsViewModel
            {
                Type = x.Type,
                Id = x.Id
            }).ToList();

            var sizeViewModel = new SizeViewModel
            {
                Type = data.Size.ToString(),
                Id = (int)data.Size
            };

            var model = new ProductPreviewModel
            {
                ProductId = data.ProductId,
                Pictures = data.Pictures.Select(x => x.PicturePath).ToList(),
                ProductName = data.ProductName,
                Colors = colorsViewModel,
                Size = sizeViewModel,
                Price = data.Price,
                Discount = data.SellingPrice.HasValue ? true : false,
                SellingPrice = data.SellingPrice,
                CategoryName = new CategoryViewModel
                {
                    Id = data.CategoryId,
                    CategoryName = data.Category.Type
                },

                //Tags = data.Tags.Select(x => x.Id).ToList(),
                Tags = tagsViewModel,
                Comment = data.Comment
            };

            return model;
        }

        /// <summary>
        /// 編輯對應Id的商品存到資料庫
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eModel"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public ApiResultModel EditById([FromForm] ProductEditModel model)
        {
            //throw new NotImplementedException();

            var data = _context.Products.Include(x => x.Colors).Include(x => x.Tags).FirstOrDefault(x => x.ProductId == model.ProductId);

            data.ProductName = model.ProductName;
            data.Colors.Clear();
            data.Colors = _context.Colors.Where(x => model.Colors.Any(y => y == x.Id)).ToList();
            data.Size = model.Size;
            data.CategoryId = model.CategoryId;
            data.Price = model.Price;

            //TODO sellingprice 本來為null 編輯時沒有更動仍是null的話會出錯
            data.SellingPrice = model.SellingPrice;
            data.Tags.Clear();
            data.Tags = _context.Tags.Where(x => model.Tags.Any(y => y == x.Id)).ToList();

            if (model.Pictures != null)
            {
                var _folder = $@"";
                var picList = new List<Picture>();
                foreach (var file in model.Pictures)
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
                data.Pictures = picList;
            }

            _context.Products.Update(data);
            _context.SaveChanges();

            return new ApiResultModel
            {
                Status = true,
                Message = "Edit Save Success!"
            };
        }

        /// <summary>
        /// 新增商品到資料庫
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

        /// <summary>
        /// 從資料庫刪除對應Id的商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public ApiResultModel DeleteById([FromBody] Int32 id)
        {
            var data = _context.Products.Include(x => x.Colors).Include(x => x.Pictures).Include(x => x.Tags).FirstOrDefault(x => x.ProductId == id);

            if (data != null)
            {
                var deletemodel = new ProductDeleteModel
                {
                    ProductName = data.ProductName,
                    Pictures = data.Pictures.Select(x => x.PicturePath).ToList(),
                    Colors = data.Colors.Select(x => x.Id).ToList(),
                    Size = data.Size,
                    Price = data.Price,
                    SellingPrice = data.SellingPrice,
                    CategoryId = data.CategoryId,
                    Tags = data.Tags.Select(x => x.Id).ToList()
                };
                _context.Products.Remove(data);
                _context.SaveChanges();
            }
            return new ApiResultModel 
            { 
                Status = true, 
                Message = "Delete Success!!"
            };
        }
    }
}