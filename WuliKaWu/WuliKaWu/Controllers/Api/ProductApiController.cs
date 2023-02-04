<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
嚜簑sing Microsoft.AspNetCore.Http;
=======
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> [��啣��]Addtocart Action
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
        /// 取得所有商品
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
>>>>>>> [靽格迤]������蝺刻摩瑼Ｚ�������Ｙ����脣��蝺刻摩������������
=======
                PicturePath = x.PicturePath,
>>>>>>> [��湔�財ProductApiController ��� GetById��寞��
=======
                PicturePath = $"~/images/{productModel.PicturePath}",
>>>>>>> [��湔�財 ProductApiController������頝臬����湔��
=======
                PicturePath = $"~/images/{x.PicturePath}",
>>>>>>> [��湔�財ProductApiController���GetAll���GetById���������頝臬��
=======
                PicturePath = x.PicturePath,
>>>>>>> [靽格迤]��������芷�斗炎閬���嫣誑vue蝬�摰�嚗���沌roductApiController�����乎etById��寞��銝行�啣��DeletePreviewModel
=======
                PicturePath = $"/images/{x.PicturePath}",
>>>>>>> [靽格迤] ��游��鞈����銵典����� Cart, whishlist 瑼Ｚ�������批�嗅�函��撘����畾�
                Price = x.Price,
                ProductId = x.ProductId,
<<<<<<< HEAD
                Size = x.Size,
<<<<<<< HEAD
                Discount = true,
                SellingPrice = x.SellingPrice.ToString() ?? "",

                Category = x.Category,

                //TODO 為什麼要轉型
                Tag = (Data.Enums.Common.Tag)x.Tag
=======
=======
                Size = x.Size.GetDescriptionText(),
>>>>>>> 撠�蝎暸�����蟡�蝳�
                Discount = x.Discount.HasValue ? x.Discount.Value > 0 ? true : false : false,
                SellingPrice = x.SellingPrice.ToString() ?? ""
>>>>>>> [靽格迤]ProductApiController���Discount撖急香�����寞��
            }).ToList();
        }

        /// <summary>
        /// 取得對應id的商品
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
        /// 編輯對應id的商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eModel"></param>
        /// <returns></returns>
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

        //TODO 商品頁面加入"收藏清單" 加Sweet Alert
        /// <summary>
        /// 商品頁面加入"收藏清單"
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

                //TODO 彈跳提醒sweetalert
            }
            // //TODO 彈跳提醒sweetalert
        }

        //TODO 商品頁面"AddToCart" SweetAlert
        /// <summary>
        /// 商品頁面加入"購物車"
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
                //TODO 彈跳提醒sweetalert
                await _context.SaveChangesAsync();
                return "已加入購物車";
            }
            //TODO 彈跳提醒sweetalert
            return "已有此商品";
        }
    }
}<<<<<<< HEAD
>>>>>>> [��湔�財 鞈����摨怨�����銵�
=======
>>>>>>> Productvue (#6)
