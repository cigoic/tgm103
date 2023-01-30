using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Mail;
using System.Security.Claims;

using WuliKaWu.Data;
using WuliKaWu.Models.ApiModel;

namespace WuliKaWu.Controllers
{
    public class MemberController : Controller
    {
        private readonly ShopContext _context;

        public MemberController(ShopContext context)
        {
            _context = context;
        }

        [ActionName("Login")]
        public IActionResult LoginRegister()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginRegisterAsync(Member model)
        {
            // 資料庫比對
            var member = _context.Members
                            .Where(x => x.Account == model.Account
                                && x.Password == model.Password)
                            .FirstOrDefault();
            //var rolesOfmember = member.Roles.Select(m => m.Type);

            if (member != null
                && model.Account == member.Account
                && model.Password == member.Password)
            {
                // 帳號密碼符合！給 cookie(s): principal > identity > claim
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, member.Name),   // 資料庫裡的姓名
                    // https://learn.microsoft.com/zh-tw/windows-server/identity/ad-fs/technical-reference/the-role-of-claims
                    new Claim(ClaimTypes.Role, ConvertRoleTypeToString(member.MemberShip)),    // 資料庫裡的角色
                    //new Claim(ClaimTypes.Role, "User"),
                    //new Claim("VIP", "1")   //可以自訂義XXX(例VIP)，但之後不能打錯
                    //new Claim(ClaimTypes.GivenName, member.FirstName),
                    //new Claim(ClaimTypes.Surname, member.LastName),
                    //new Claim(ClaimTypes.Email, member.Email),
                    //new Claim(ClaimTypes.Gender, member.Gender), // TODO    to string
                    //new Claim(ClaimTypes.DateOfBirth, member.Birthday), // TODO    to string
                    //new Claim(ClaimTypes.HomePhone, member.PhoneNumber),
                    //new Claim(ClaimTypes.MobilePhone, member.MobilePhone),
                };

                // TODO
                //foreach (var role in rolesOfmember)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, ConvertRoleTypeToString(role)));
                //}

                // 直接定義這是"身分證明"
                // 指定 Authentication Type 名稱，以是任何詞彙，但前後端設定必須一致
                // 如果無法，可用 CookieAuthenticationDefaults.AuthenticationScheme
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity); // 到時候要用的憑證

                //HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties()
                //{
                // 何時過期...或填空值
                //});
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }

            TempData["error"] = "帳號密碼不對！";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public void SendMail()
        {
            var mail = new MailMessage();
            mail.Subject = "您好！";
            mail.IsBodyHtml = true;
            mail.Body = "< h1 > Happy New Year~</ h1 >";
            mail.From = new MailAddress("liang.case@gmail.com");
            mail.To.Add(new MailAddress("liang.case@me.com"));

            var client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("liang.case@gmail.com", "MY_PASSWORD");
            client.Send(mail);  // 寄信
        }

        // GET  /Member/MyAccount
        /// <summary>
        /// My Account 檢視頁面入口
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        //[Authorize]
        public IActionResult MyAccount(int MemberId)    // TODO 如何找到會員 ID/Role/Name?
        {
            if (User.Identity.IsAuthenticated)
            {
                var userclaim = User.Claims.Select(c => c.Subject.Claims).FirstOrDefault().ToList();
                var roletype = userclaim[1].Value;
                //var member = _context.Members.Where(m => m.MemberId == MemberId).FirstOrDefault();
                //return View(username);
            }
            return View();
        }

        // TODO 收取提交表單資料,並寫入會員資料庫
        // POST /Member/AccountDetails
        /// <summary>
        /// 更改會員資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AccountDetailsAsync([Bind("FirstName, LastName, DisplayName, Email, CurrentPwd, NewPwd, ConfirmPwd")] AccountDetailsModel model)
        public async Task<IActionResult> AccountDetailsAsync([FromBody] AccountDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(model);
                //await _context.SaveChangesAsync();
                return Ok("成功收取");
            }
            return RedirectToAction(nameof(MyAccount));
        }

        /// <summary>
        /// 轉換會員類型代號至字串
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        private string ConvertRoleTypeToString(MemberShipType role) //TODO  可能須修正為 RoleType
        {
            switch (role)
            {
                case MemberShipType.NormalUser:
                    return "User";
                    break;
                case MemberShipType.VIP:
                    return "VIP";
                    break;
                case MemberShipType.Admin:
                    return "Admin";
                    break;
                case MemberShipType.None:
                default:
                    return "None";
                    break;
            }
        }
    }
}