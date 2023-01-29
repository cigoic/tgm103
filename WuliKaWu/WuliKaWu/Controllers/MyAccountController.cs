using Microsoft.AspNetCore.Mvc;

using WuliKaWu.Data;

namespace WuliKaWu.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly ShopContext _context;

        public MyAccountController(ShopContext context)
        {
            _context = context;
        }


    }
}
