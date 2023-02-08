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
        /// ���o�Ҧ��ӫ~
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
        /// ���o����id���ӫ~
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ProductPreviewModel GetById(int id)
        {
            var data = _context.Products.Include(x => x.Pictures).Include(x => x.Colors).Include(x => x.Tags).FirstOrDefault(x => x.ProductId == id);

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
}