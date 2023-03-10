using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WuliKaWu.Models;

namespace WuliKaWu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 關於我們
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// 部落格
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Blog()
        {
            return View();
        }

        /// <summary>
        /// 部落格文章
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult BlogDetails()
        {
            return View();
        }

        /// <summary>
        /// 部落格測邊欄
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult BlogSidebar()
        {
            return View();
        }

        /// <summary>
        /// 購物車
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Cart()
        {
            return View();
        }

        /// <summary>
        /// 結帳
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [ActionName("Checkout")]
        public IActionResult CheckoutCart()
        {
            return View();
        }

        /// <summary>
        /// 產品比較
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [ActionName("Compare")]
        public IActionResult CompareProducts()
        {
            return View();
        }

        /// <summary>
        /// 聯絡我們
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ContactUs()
        {
            return View();
        }

        /// <summary>
        /// 首頁 1
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexOne()
        {
            return View();
        }

        /// <summary>
        /// 首頁 2
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexTwo()
        {
            return View();
        }

        /// <summary>
        /// 首頁 3
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexThree()
        {
            return View();
        }

        /// <summary>
        /// 首頁 4
        /// </summary>
        /// <returns></returns>
        [ActionName("Index")]
        public IActionResult IndexFour()
        {
            return View();
        }

        /// <summary>
        /// 首頁 5
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexFive()
        {
            return View();
        }

        /// <summary>
        /// 首頁 6
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexSix()
        {
            return View();
        }

        /// <summary>
        /// 首頁 7
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexSeven()
        {
            return View();
        }

        /// <summary>
        /// 首頁 8
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult IndexEight()
        {
            return View();
        }

        /// <summary>
        /// 會員登入、註冊
        /// 請改用自訂控制器來實作、或使用 Identity 範本
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult LoginRegister()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult MyAccount()
        {
            return View();
        }

        // TODO: 製作隱私聲明套版
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// 產品資訊 1
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ProductDetails()
        {
            return View();
        }

        /// <summary>
        /// 產品資訊 2
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ProductDetailsTwo()
        {
            return View();
        }

        /// <summary>
        /// 產品聯盟行銷
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ProductDetailsAffiliate()
        {
            return View();
        }

        /// <summary>
        /// 產品細節 - 固定尺寸影像
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ProductDetailsFixedImg()
        {
            return View();
        }

        /// <summary>
        /// 產品細節 - 集錦集
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ProductDetailsGallery()
        {
            return View();
        }

        /// <summary>
        /// 產品細節 - 群組
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ProductDetailsGroup()
        {
            return View();
        }

        /// <summary>
        /// 購物
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Shop()
        {
            return View();
        }

        /// <summary>
        /// 購物清單
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ShopList()
        {
            return View();
        }

        /// <summary>
        /// 產品購物清單 - List 側欄
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ShopListSidebar()
        {
            return View();
        }

        /// <summary>
        /// 商店位置
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ShopLocation()
        {
            return View();
        }

        /// <summary>
        /// 產品購物清單 - 右側欄
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ShopRightSidebar()
        {
            return View();
        }

        /// <summary>
        /// 產品購物清單 - 側邊欄位
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult ShopSidebar()
        {
            return View();
        }

        /// <summary>
        /// 願望清單
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult WishList()
        {
            return View();
        }

        /// <summary>
        /// 網站錯誤顯示
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}