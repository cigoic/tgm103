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
                PicturePath = x.PicturePath,
                Price = x.Price,
                ProductId = x.ProductId,
                Size = x.Size.GetDescriptionText(),
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
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

        //TODO �ӫ~�����[�J"���òM��" �[Sweet Alert
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

                //TODO �u������sweetalert
            }
            // //TODO �u������sweetalert
        }

        //TODO �ӫ~����"AddToCart" SweetAlert
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
                //TODO �u������sweetalert
                _context.SaveChangesAsync();
                return "�w�[�J�ʪ���";
            }
            //TODO �u������sweetalert
            return "�w�����ӫ~";
        }
    }
}