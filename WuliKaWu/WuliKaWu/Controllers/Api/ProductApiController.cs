using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models.ApiModel;
using static WuliKaWu.Data.Enums.Common;

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

        /// <summary>
        /// 取得所有商品
        /// </summary>
        /// <returns></returns>

        public List<ProductModel> GetAll()
        {
            return _context.Products.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                Color = x.Color,
                PicturePath = x.PicturePath,
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size.GetDescriptionText(),
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
            }).ToList();
        }

        /// <summary>
        /// 取得對應id的商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public PreviewModel GetById(int id)
        {
            var data = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (data == null)
            {
                return null;
            }
            var model = new PreviewModel
            {
                ProductId = data.ProductId,
                PicturePath = data.PicturePath,
                ProductName = data.ProductName,
                Color = data.Color,
                Size = data.Size.GetDescriptionText(),
                Price = data.Price,
                Discount = data.Discount.HasValue ? data.Discount.Value > 0 ? true : false : false,
                SellingPrice = data.SellingPrice.HasValue ? data.SellingPrice.Value.ToString() : "",
                Category = data.Category,
                Tag = (Tag)data.Tag
            };

            return model;
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
            Product product = _context.Products.Find(id);
            product.ProductName = eModel.ProductName;
            product.Color = eModel.Color;
            product.Size = (Size)Enum.Parse(typeof(Size), eModel.Size);
            product.Category = eModel.Category;
            product.PicturePath = eModel.PicturePath;
            product.Price = eModel.Price;
            product.Discount = Convert.ToDecimal(eModel.Discount);
            product.SellingPrice = decimal.Parse(eModel.SellingPrice);
            product.Tag = (Tag)eModel.Tag;

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

            return eModel;
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        /// <summary>
        /// 新增商品至資料庫
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<String> AddProduct(AddModel addModel)
        {
            Product prd = new Product
            {
                ProductName = addModel.ProductName,
                Color = addModel.Color,
                Size = addModel.Size,
                PicturePath = addModel.PicturePath,
                Price = addModel.Price,
                Discount = addModel.Discount,
                SellingPrice = addModel.SellingPrice,
                Category = addModel.Category,
                Tag = addModel.Tag
            };

            _context.Add(prd);
            await _context.SaveChangesAsync();

            return "Create Success!!";
        }
    }
}