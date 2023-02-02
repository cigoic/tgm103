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
                PicturePath = x.PicturePath,
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size.GetDescriptionText(),
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
            }).ToList();
        }

        [HttpGet("{id}")]
        public DeleteforPreviewModel GetById(int id)
        {
            var data = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (data == null)
            {
                return null;
            }
            return new DeleteforPreviewModel
            {
                PicturePath = data.PicturePath,
                ProductName = data.ProductName,
                Color = data.Color,
                Size = data.Size.GetDescriptionText(),
                Price = data.Price,
                SellingPrice = data.SellingPrice.HasValue ? data.SellingPrice.Value.ToString() : "",
                Category = data.Category,
                Tag = (Tag)data.Tag
            };
        }

        public ProductModel EditById(int id, ProductModel productModel)
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
            product.PicturePath = productModel.PicturePath;
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

        //TODO 商品頁面加入"收藏清單" 加Sweet Alert
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
                return "已加入收藏清單";
            }
            return "目前沒有收藏商品";
        }

        //TODO 商品頁面"AddToCart"
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
                return "已加入購物車";
            }
            return "";
        }
    }
}