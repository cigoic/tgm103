using Microsoft.AspNetCore.Mvc;

using System.Xml.Linq;

namespace WuliKaWu.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AccountDetails(string FirstName, string LastName, string DisplayName, string Email, string CurrentPwd, string NewPwd, string ConfirmPwd)
        {
            return Ok("成功收取");
            //return RedirectToAction("Index");
        }
    }
}
