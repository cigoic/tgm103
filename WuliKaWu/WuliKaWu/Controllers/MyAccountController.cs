using Microsoft.AspNetCore.Mvc;

namespace WuliKaWu.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
