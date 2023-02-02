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

        public List<ProductModel> GetAll()
        {
            return _context.Products.Select(x => new ProductModel
            {
                ProductName = x.ProductName,
                Color = x.Color,
                PicturePath = $"/images/{x.PicturePath}",
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size.GetDescriptionText(),
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
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

        //TODO 商品頁面加入"收藏清單" 加Sweet Alert
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

                //TODO 彈跳提醒sweetalert
            }
            // //TODO 彈跳提醒sweetalert
        }

        //TODO 商品頁面"AddToCart" SweetAlert
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
                //TODO 彈跳提醒sweetalert
                _context.SaveChangesAsync();
                return "已加入購物車";
            }
            //TODO 彈跳提醒sweetalert
            return "已有此商品";
        }
    }
}