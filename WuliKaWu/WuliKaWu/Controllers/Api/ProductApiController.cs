<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
Ôªøusing Microsoft.AspNetCore.Http;
=======
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> [Êñ∞Â¢û]Addtocart Action
using Microsoft.AspNetCore.Http;
>>>>>>> Productvue (#6)
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
        /// ®˙±o©“¶≥∞”´~
        /// </summary>
        /// <returns></returns>

        public List<ProductModel> GetAll()
        {
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
>>>>>>> [‰øÆÊ≠£]ÂïÜÂìÅÁ∑®ËºØÊ™¢Ë¶ñÈ†ÅÈù¢ÁöÑÂÑ≤Â≠òÁ∑®ËºØÊåâÈàïÈÄ£Âãï
=======
                PicturePath = x.PicturePath,
>>>>>>> [Êõ¥Êñ∞]ProductApiController ÁöÑ GetByIdÊñπÊ≥ï
=======
                PicturePath = $"~/images/{productModel.PicturePath}",
>>>>>>> [Êõ¥Êñ∞] ProductApiControllerÂúñÁâáË∑ØÂæëÊõ¥Êñ∞
=======
                PicturePath = $"~/images/{x.PicturePath}",
>>>>>>> [Êõ¥Êñ∞]ProductApiControllerÁöÑGetAllÂèäGetByIdÁöÑÂúñÁâáË∑ØÂæë
=======
                PicturePath = x.PicturePath,
>>>>>>> [‰øÆÊ≠£]ÂïÜÂìÅÂà™Èô§Ê™¢Ë¶ñÊîπ‰ª•vueÁ∂ÅÂÆöÔºåÂú®ProductApiControllerÂä†ÂÖ•GetByIdÊñπÊ≥ï‰∏¶Êñ∞Â¢ûDeletePreviewModel
=======
                PicturePath = $"/images/{x.PicturePath}",
>>>>>>> [‰øÆÊ≠£] Êõ¥ÂãïË≥áÊñôË°®ÂæåÁöÑ Cart, whishlist Ê™¢Ë¶ñËàáÊéßÂà∂Âô®Á®ãÂºèÁâáÊÆµ
                Price = x.Price,
                ProductId = x.ProductId,
<<<<<<< HEAD
                Size = x.Size,
<<<<<<< HEAD
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO ¨∞§∞ªÚ≠n¬‡´¨
                Tag = (Data.Enums.Common.Tag)x.Tag
=======
=======
                Size = x.Size.GetDescriptionText(),
>>>>>>> Â∞èÁ≤æÈùàÁöÑÁ•ùÁ¶è
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
>>>>>>> [‰øÆÊ≠£]ProductApiControllerÁöÑDiscountÂØ´Ê≠ªÁöÑÊîπÊéâ
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
>>>>>>> DB‰øÆÊîπ
        }

        /// <summary>
        /// ®˙±oπÔ¿≥id™∫∞”´~
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
        /// ΩsøËπÔ¿≥id™∫∞”´~
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
        /// ∑sºW∞”´~¶‹∏ÍÆ∆Æw
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<String> AddProduct(AddModel addModel)
        {
            throw new NotImplementedException();

            //Product prd = new Product
            //{
            //    ProductName = addModel.ProductName,
            //    Color = addModel.Color,
            //    Size = addModel.Size,
            //    PicturePath = addModel.PicturePath,
            //    Price = addModel.Price,
            //    Discount = addModel.Discount,
            //    SellingPrice = addModel.SellingPrice,
            //    CategoryId = (int)addModel.Category,
            //    Tag = addModel.Tag
            //};

            //_context.Add(prd);
            //await _context.SaveChangesAsync();

            //return "Create Success!!";
        }

        //TODO ∞”´~≠∂≠±•[§J"¶¨¬√≤M≥Ê" •[Sweet Alert
        /// <summary>
        /// ∞”´~≠∂≠±•[§J"¶¨¬√≤M≥Ê"
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

                //TODO ºu∏ı¥£øÙsweetalert
                return new ApiResultModel
                {
                    Status = true,
                    Message = "•[§J¶®•\"
                };
            }
            // //TODO ºu∏ı¥£øÙsweetalert
            return new ApiResultModel
            {
                Status = false,
                Message = "§w©Ò§J¶¨¬√≤M≥Ê"
            };
        }

        //TODO ∞”´~≠∂≠±"AddToCart" SweetAlert
        /// <summary>
        /// ∞”´~≠∂≠±•[§J"¡ ™´®Æ"
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
                //TODO ºu∏ı¥£øÙsweetalert
                await _context.SaveChangesAsync();
                return "§w•[§J¡ ™´®Æ";
            }
            //TODO ºu∏ı¥£øÙsweetalert
            return "§w¶≥¶π∞”´~";
        }
    }
}<<<<<<< HEAD
>>>>>>> [Êõ¥Êñ∞] Ë≥áÊñôÂ∫´Ë≥áÊñôË°®
=======
>>>>>>> Productvue (#6)
