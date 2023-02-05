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
        /// ���o�Ҧ��ӫ~
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
        /// ���o����id���ӫ~
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
        /// �s�����id���ӫ~
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
        /// �s�W�ӫ~�ܸ�Ʈw
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

        //TODO �ӫ~�����[�J"���òM��" �[Sweet Alert
        /// <summary>
        /// �ӫ~�����[�J"���òM��"
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("{productId}")]
        public async Task<ApiResultModel> AddWishListAsync(int productId)
        {
            var myId = User.Claims.GetMemberId();
            var wishItem = await _context.WishList.FirstOrDefaultAsync(x => x.MemberId == myId && x.ProductId == productId);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            if (wishItem == null)
            {
                _context.WishList.Add(new WishList
                {
                    ProductId = productId,
                    MemberId = myId,
                    //Product = product
                });

                //var CountOfRecords = await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();

                //TODO �u������sweetalert
                return new ApiResultModel
                {
                    Status = true,
                    Message = "�[�J���\"
                };
            }
            // //TODO �u������sweetalert
            return new ApiResultModel
            {
                Status = false,
                Message = "�w��J���òM��"
            };
        }

        //TODO �ӫ~����"AddToCart" SweetAlert
        /// <summary>
        /// �ӫ~�����[�J"�ʪ���"
        /// </summary>
        /// <param name="WishListId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("{productId}")]
        public async Task<string> AddToCartAsync(int WishListId, int productId)
        {
            var myId = User.Claims.GetMemberId();
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.MemberId == myId);
            if (cart == null)
            {
                cart = new Cart();
            }

            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            if (cart != null)
            {
                _context.Carts.Add(new Cart
                {
                    //WishListId = WishListId,
                    //MemberId = myId,
                    //ProductId = productId,
                    Quantity = 1,
                    Product = product
                });
                //TODO �u������sweetalert
                await _context.SaveChangesAsync();
                return "�w�[�J�ʪ���";
            }
            //TODO �u������sweetalert
            return "�w�����ӫ~";
        }
    }
}