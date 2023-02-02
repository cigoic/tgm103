<<<<<<< HEAD
<<<<<<< HEAD
=======
Ôªøusing Microsoft.AspNetCore.Http;
=======
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
            product.Size = (Size)Enum.Parse(typeof(Size), productModel.Size);
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

        //TODO ∞”´~≠∂≠±•[§J"¶¨¬√≤M≥Ê" •[Sweet Alert
        //[Authorize]
        [HttpPost("{productId}")]
        public string AddWishList(int productId)
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
                    ProductName = product.ProductName,
                    Price = product.Price,
                    SellingPrice = (decimal)product.SellingPrice,
                    Discount = (decimal)product.Discount,
                    PicturePath = product.PicturePath
                });
                //_context.WishList.Update(wishItem);
                _context.SaveChangesAsync();
                return "§w•[§J¶¨¬√≤M≥Ê";
            }
            return "•ÿ´e®S¶≥¶¨¬√∞”´~";
        }

        //TODO ∞”´~≠∂≠±"AddToCart"
        [HttpPost("{productId}")]
        public string AddToCart(int productId)
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
                });
                _context.SaveChanges();
                return "§w•[§J¡ ™´®Æ";
            }
            return "";
        }
    }
}<<<<<<< HEAD
>>>>>>> [Êõ¥Êñ∞] Ë≥áÊñôÂ∫´Ë≥áÊñôË°®
=======
>>>>>>> Productvue (#6)
