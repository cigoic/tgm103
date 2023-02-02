<<<<<<< HEAD
<<<<<<< HEAD
=======
﻿using Microsoft.AspNetCore.Http;
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
<<<<<<< HEAD
                PicturePath = "~/assets/images/product/product-5.png",
>>>>>>> [修正]商品編輯檢視頁面的儲存編輯按鈕連動
=======
                PicturePath = x.PicturePath,
>>>>>>> [更新]ProductApiController 的 GetById方法
=======
                PicturePath = $"~/images/{productModel.PicturePath}",
>>>>>>> [更新] ProductApiController圖片路徑更新
=======
                PicturePath = $"~/images/{x.PicturePath}",
>>>>>>> [更新]ProductApiController的GetAll及GetById的圖片路徑
=======
                PicturePath = x.PicturePath,
>>>>>>> [修正]商品刪除檢視改以vue綁定，在ProductApiController加入GetById方法並新增DeletePreviewModel
                Price = x.Price,
                ProductId = x.ProductId,
<<<<<<< HEAD
                Size = x.Size,
<<<<<<< HEAD
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO ������n�૬
                Tag = (Data.Enums.Common.Tag)x.Tag
=======
=======
                Size = x.Size.GetDescriptionText(),
>>>>>>> 小精靈的祝福
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
>>>>>>> [修正]ProductApiController的Discount寫死的改掉
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

        //TODO �ӫ~�����[�J"���òM��" �[Sweet Alert
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
                return "�w�[�J���òM��";
            }
            return "�ثe�S�����ðӫ~";
        }

        //TODO �ӫ~����"AddToCart"
        [HttpPost("{productId}")]
        public string AddToCart(int WishListId, int productId)
        {
            var myId = User.Claims.GetMemberId();
            var cart = _context.Cart.FirstOrDefault(x => x.MemberId == myId);
            var product = _context.Products.FirstOrDefault(x => x.ProductId == WishListId);
            if (cartItem == null)
            {
                _context.WishList.Add(new WishList
                {
                    WishListId = WishListId,
                    MemberId = myId,
                    ProductName = WishListId.ProductName,
                    Price = WishListId.Price,
                    SellingPrice = (decimal)WishListId.SellingPrice,
                    Discount = (decimal)WishListId.Discount,
                    PicturePath = WishListId.PicturePath
                });
                _context.SaveChangesAsync();
                return "�w�[�J�ʪ���";
            }
            return "";
        }
    }
}<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
>>>>>>> Productvue (#6)
