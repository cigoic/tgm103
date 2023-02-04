<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
﻿using Microsoft.AspNetCore.Http;
=======
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> [新增]Addtocart Action
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
=======
                PicturePath = $"/images/{x.PicturePath}",
>>>>>>> [修正] 更動資料表後的 Cart, whishlist 檢視與控制器程式片段
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
        /// <summary>
        /// �ӫ~�����[�J"���òM��"
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("{productId}")]
        public async Task AddWishListAsync(int productId)
        {
            var myId = User.Claims.GetMemberId();
            var wishItem = await _context.WishList.FirstOrDefaultAsync(x => x.MemberId == myId && x.ProductId == productId);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            if (wishItem == null)
            {
                _context.WishList.Add(new WishList
                {
                    ProductId = productId,
                    //MemberId = myId,
                    Product = product
                });

                //var CountOfRecords = await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();

                //TODO �u������sweetalert
            }
            // //TODO �u������sweetalert
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
}<<<<<<< HEAD
>>>>>>> [更新] 資料庫資料表
=======
>>>>>>> Productvue (#6)
