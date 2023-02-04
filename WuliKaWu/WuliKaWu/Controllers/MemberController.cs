using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;
using WuliKaWu.Models.ApiModel;

using static WuliKaWu.Data.MemberRole;

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
        public async Task<IActionResult> LoginRegisterAsync(MemberLoginModel model)
        {
            // 資料庫比對
            var member = _context.Members
                            .SingleOrDefault(x => x.Account == model.Account);

            if (member == null || !BCrypt.Net.BCrypt.Verify(model.Password, member.Password))
            {
                TempData["error"] = "帳號密碼不對！";
                return RedirectToAction("Login");
            }

            //var rolesOfmember = member.Roles.Select(m => m.Type);

            // 帳號密碼符合！給 cookie(s): principal > identity > claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, member.Name),   // 資料庫裡的姓名
                // https://learn.microsoft.com/zh-tw/windows-server/identity/ad-fs/technical-reference/the-role-of-claims
                new Claim(ClaimTypes.Role, RoleType.User.GetDescriptionText()),    // 資料庫裡的角色
                //new Claim(ClaimTypes.Role, "User"),
                //new Claim("VIP", "1")   //可以自訂義XXX(例VIP)，但之後不能打錯
                //new Claim("Id", member.MemberId.ToString()),
                new Claim("RememberMe", model.RememberMe.ToString()),
                new Claim(ClaimTypes.Sid, member.MemberId.ToString()),
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

        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model == null)
                return RedirectToAction("Login");

            if (_context.Members.Any(u => u.Account == model.Account))
            {
                TempData["error"] = "輸入有誤！請再試一次";
                return RedirectToAction("Login");  //TODO: 提示訊息
            }

            if (_context.Members.Any(u => u.Email == model.Email))
            {
                TempData["error"] = "輸入有誤！請再試一次";
                return RedirectToAction("Login");  //TODO: 提示訊息
            }

            if (ModelState.IsValid)
            {
                Member member = new Member();
                member.Account = model.Account;
                // Hash the password
                // Install-Package BCrypt.Net-Next
                member.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                member.Name = model.Name;
                member.Gender = model.Gender;
                member.Birthday = model.Birthday;
                member.EmailComfirmed = false;
                member.Email = model.Email;
                member.Address = model.Address;
                member.PhoneNumber = model.PhoneNumber;
                member.MobilePhone = model.MobilePhone;
                member.MemberShip = MemberShipType.NormalUser;
                member.LockOutEnabled = false;
                member.AccessFailedCount = 0;

                _context.Members.Add(member);

                //TODO: 在收到信箱認證後給予
                //MemberRole role = new MemberRole();
                //role.MemberId = //model.MemberId;
                //role.Type = MemberRole.RoleType.User;
                //_context.MemberRoles.Add(role);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Login");
        }

        /// <summary>
        /// 登出帳號，同時清除 Session
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            if (HttpContext.Session != null)
                HttpContext.Session.Clear();    // 清除 Session

            return RedirectToAction("Index", "Home");
        }

        //  GET /Member/ForgetPassword
        /// <summary>
        /// 會員的[忘記密碼]功能
        /// </summary>
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }

        /// <summary>
        /// 會員的[忘記密碼]功能
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ActionName("ForgetPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgetPasswordAsync(ForgetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // 檢查用戶是否存在?
                var user = _context.Members
                            .Any(m => m.Account == model.Account
                            && m.Email == model.Email);
                if (user == false)
                {
                    // TODO 如果找不到用戶, 丟出錯誤顯示
                    ModelState.AddModelError("", "此用戶尚未註冊!");
                    return View();
                }

                // 產生重置密碼 token
                Guid ResetToken = await GeneratePasswordResetTokenAsync(user);

                if (ResetToken == Guid.Empty)
                    return View();

                // TODO 寄送重置密碼連結
                SendPasswordResetEmail(ResetToken);

                // TODO  通知用戶密碼確認信已寄出
            }

            return View();
        }

        public async Task<Guid> GeneratePasswordResetTokenAsync(bool HasUser)
        {
            if (HasUser == false) return Guid.Empty;

            Guid ResetToken = Guid.NewGuid();

            if (await _context.ResetTokens.AnyAsync(t => t.Token == ResetToken))
                return Guid.Empty;

            return ResetToken;
        }

        private void SendPasswordResetEmail(Guid ResetToken)
        {
            var mail = new MailMessage();
            mail.Subject = "您好！";
            mail.SubjectEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Body = $"<h1>密碼重設 Token: {ResetToken} </h1>";
            mail.From = new MailAddress("liang.case@gmail.com");
            mail.To.Add(new MailAddress("liang.case@me.com"));

            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("liang.case@gmail.com", "APP_PASSWORD");
                client.Send(mail);  // 寄信
            }
        }

        public IActionResult ResetPassword(Guid ResetToken)
        {
            if (_context.ResetTokens.Any(t => t.Token != ResetToken))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            if (ModelState.IsValid == false) return View();

            var ResetToken = _context.ResetTokens.FirstOrDefaultAsync(t => t.Token == model.ResetToken).Result;
            var member = _context.Members.FirstOrDefaultAsync(t => t.MemberId == ResetToken.MemberId).Result;

            if (ResetToken == null || member == null) return RedirectToAction("ForgetPassword");

            // 產生新密碼,更新回資料庫
            var CryptedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
            member.Password = CryptedPassword;

            _context.Entry(member).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return View();
        }

        // GET  /Member/MyAccount
        /// <summary>
        /// My Account 檢視頁面入口
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        //[Authorize]
        public IActionResult MyAccount()
        {
            return View();
        }

        // TODO 收取提交表單資料,並寫入會員資料庫
        // POST /Member/AccountDetails
        /// <summary>
        /// 更改會員資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> MyAccount(AccountDetailsModel model)
        {
            if (User.Identity.IsAuthenticated == false || ModelState.IsValid == false)
                return RedirectToAction("Index", "Home");

            //var model = new MemberModel();
            //model.MemberId = User.Claims.GetMemberId();
            //model.Name = User.Identity.Name;
            //model.RememberMe = User.Claims.GetRememberMeStatus();
            //return View(model);

            var member = _context.Members
                .FirstOrDefault(m => m.MemberId == User.Claims.GetMemberId());

            if (member == null)
                return RedirectToAction("Login");

            member.Name = $"{model.LastName}+{model.FirstName}";
            member.Email = model.Email;
            //ComparePassword(model);   //TODO
            member.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPwd);

            _context.Members.Update(member);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyAccount));
        }
    }
}