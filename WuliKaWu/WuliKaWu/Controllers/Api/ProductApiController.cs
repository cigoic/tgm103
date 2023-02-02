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

        [HttpPost("{id}")]
        public EditModel EditById(int id, EditModel eModel)
        {
            if (id != eModel.ProductId)
            {
                return null;
            }

            Product product = _context.Products.Find(eModel.ProductId);
            product.ProductId = eModel.ProductId;
            product.ProductName = eModel.ProductName;
            product.Color = eModel.Color;
            product.Size = (Size)Enum.Parse(typeof(Size), eModel.Size);
            product.Category = eModel.Category;
            product.PicturePath = eModel.PicturePath;
            product.Price = eModel.Price;
            product.Discount = Convert.ToDecimal(eModel.Discount);
            product.SellingPrice = decimal.Parse(eModel.SellingPrice);
            product.Tag = (Tag)eModel.Tag;

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

            return eModel;
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        //[HttpDelete("{id}")]
        //public async Task<String> DeleteProduct(int id)
        //{
        //    Product p = await _context.Products.FindAsync(id);
        //    if (p == null)
        //    {
        //        return "can not find this product!";
        //    }

        //    _context.Products.Remove(p);
        //    await _context.SaveChangesAsync();
        //    return "this product delete success!";
        //}

        //TODO °Ó«~­¶­±¥[¤J"¦¬ÂÃ²M³æ" ¥[Sweet Alert
        //[Authorize]
        [HttpPost("{productId}")]
        public void AddWishList(int productId)
        {
            var myId = User.Claims.GetMemberId();
            var wishItem = _context.WishList.FirstOrDefault(x => x.MemberId == myId && x.ProductId == productId);
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);

            if (wishItem == null)
            {
                _context.WishList.Add(new WishList
                {
                    ProductId = productId,
                    MemberId = myId,
                    Product = product
                });

                _context.SaveChangesAsync();

                //TODO ¼u¸õ´£¿ôsweetalert
            }
            // //TODO ¼u¸õ´£¿ôsweetalert
        }

        //TODO °Ó«~­¶­±"AddToCart" SweetAlert
        //[Authorize]
        [HttpPost("{productId}")]
        public string AddToCart(int WishListId, int productId)
        {
            var myId = User.Claims.GetMemberId();
            var cart = _context.Carts.FirstOrDefault(x => x.MemberId == myId && x.ProductId == productId);
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);

            if (cart == null)
            {
                _context.Carts.Add(new Cart
                {
                    //WishListId = WishListId,
                    MemberId = myId,
                    ProductId = productId,
                    Quantity = 1,
                    Product = product
                });
                //TODO ¼u¸õ´£¿ôsweetalert
                _context.SaveChangesAsync();
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
