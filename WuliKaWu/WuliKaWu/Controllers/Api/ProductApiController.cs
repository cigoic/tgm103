<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
ï»¿using Microsoft.AspNetCore.Http;
=======
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> [æ–°å¢]Addtocart Action
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
        /// ¨ú±o©Ò¦³°Ó«~
        /// </summary>
        /// <returns></returns>

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                PicturePath = "~/assets/images/product/product-5.png",
>>>>>>> [ä¿®æ­£]å•†å“ç·¨è¼¯æª¢è¦–é é¢çš„å„²å­˜ç·¨è¼¯æŒ‰éˆ•é€£å‹•
=======
                PicturePath = x.PicturePath,
>>>>>>> [æ›´æ–°]ProductApiController çš„ GetByIdæ–¹æ³•
=======
                PicturePath = $"~/images/{productModel.PicturePath}",
>>>>>>> [æ›´æ–°] ProductApiControlleråœ–ç‰‡è·¯å¾‘æ›´æ–°
=======
                PicturePath = $"~/images/{x.PicturePath}",
>>>>>>> [æ›´æ–°]ProductApiControllerçš„GetAllåŠGetByIdçš„åœ–ç‰‡è·¯å¾‘
=======
                PicturePath = x.PicturePath,
>>>>>>> [ä¿®æ­£]å•†å“åˆªé™¤æª¢è¦–æ”¹ä»¥vueç¶å®šï¼Œåœ¨ProductApiControlleråŠ å…¥GetByIdæ–¹æ³•ä¸¦æ–°å¢DeletePreviewModel
=======
                PicturePath = $"/images/{x.PicturePath}",
>>>>>>> [ä¿®æ­£] æ›´å‹•è³‡æ–™è¡¨å¾Œçš„ Cart, whishlist æª¢è¦–èˆ‡æ§åˆ¶å™¨ç¨‹å¼ç‰‡æ®µ
                Price = x.Price,
                ProductId = x.ProductId,
<<<<<<< HEAD
                Size = x.Size,
<<<<<<< HEAD
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO ¬°¤°»ò­nÂà«¬
                Tag = (Data.Enums.Common.Tag)x.Tag
=======
=======
                Size = x.Size.GetDescriptionText(),
>>>>>>> å°ç²¾éˆçš„ç¥ç¦
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
>>>>>>> [ä¿®æ­£]ProductApiControllerçš„Discountå¯«æ­»çš„æ”¹æ‰
            }).ToList();
        }

        /// <summary>
        /// ¨ú±o¹ïÀ³idªº°Ó«~
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
                Category = (Category)data.CategoryId,
                Tag = (Tag)data.Tag
            };

            return model;
        }

        /// <summary>
        /// ½s¿è¹ïÀ³idªº°Ó«~
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
            product.CategoryId = (int)eModel.Category;
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
        /// ·s¼W°Ó«~¦Ü¸ê®Æ®w
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
                CategoryId = (int)addModel.Category,
                Tag = addModel.Tag
            };

            _context.Add(prd);
            await _context.SaveChangesAsync();

            return "Create Success!!";
        }

        //TODO °Ó«~­¶­±¥[¤J"¦¬ÂÃ²M³æ" ¥[Sweet Alert
        /// <summary>
        /// °Ó«~­¶­±¥[¤J"¦¬ÂÃ²M³æ"
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

                //TODO ¼u¸õ´£¿ôsweetalert
                return new ApiResultModel
                {
                    Status = true,
                    Message = "¥[¤J¦¨¥\"
                };
            }
            // //TODO ¼u¸õ´£¿ôsweetalert
            return new ApiResultModel
            {
                Status = false,
                Message = "¤w©ñ¤J¦¬ÂÃ²M³æ"
            };
        }

        //TODO °Ó«~­¶­±"AddToCart" SweetAlert
        /// <summary>
        /// °Ó«~­¶­±¥[¤J"ÁÊª«¨®"
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
                //TODO ¼u¸õ´£¿ôsweetalert
                await _context.SaveChangesAsync();
                return "¤w¥[¤JÁÊª«¨®";
            }
            //TODO ¼u¸õ´£¿ôsweetalert
            return "¤w¦³¦¹°Ó«~";
        }
    }
}<<<<<<< HEAD
>>>>>>> [æ›´æ–°] è³‡æ–™åº«è³‡æ–™è¡¨
=======
>>>>>>> Productvue (#6)
