﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
<<<<<<< HEAD
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Web;

using WuliKaWu.Data;
using WuliKaWu.Extensions;
using WuliKaWu.Models;
using WuliKaWu.Models.ApiModel;

using static WuliKaWu.Data.MemberRole;

namespace WuliKaWu.Controllers
{
    /// <summary>
    /// 會員登入系統
    /// 提供「登入」、「註冊」、「忘記密碼」功能
    /// </summary>
    public class MemberController : Controller
    {
        private readonly ShopContext _context;
        private readonly IConfiguration _configuration;

        public MemberController(ShopContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// 會員登入、註冊首頁
        /// </summary>
        /// <returns></returns>
=======
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> [更新] 將會員資訊頁併入 Member 控制器與檢視, 調整 _Layout 連結, 顯示會員資訊以及修改功能需要補齊
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
<<<<<<< HEAD
>>>>>>> [新增] 自訂會員註冊控制器與登入畫面與 Member 表，修正 _Layout 連結
=======
        private readonly ShopContext _context;

        public MemberController(ShopContext context)
        {
            _context = context;
        }

>>>>>>> [更新] 將會員資訊頁併入 Member 控制器與檢視, 調整 _Layout 連結, 顯示會員資訊以及修改功能需要補齊
        [ActionName("Login")]
        public IActionResult LoginRegister()
        {
            return View();
        }

<<<<<<< HEAD
        /// <summary>
        /// 會員登入
        /// </summary>
        /// <param name="model">登入所需資訊</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> LoginRegisterAsync([FromBody] MemberLoginModel model)
        {
            // 資料庫比對
            var member = _context.Members
                            .SingleOrDefault(x => x.Account == model.Account && x.EmailComfirmed == true);

            if (member == null || !BCrypt.Net.BCrypt.Verify(model.Password, member.Password))
            {
                return BadRequest(new { success = false, message = "錯誤，請再試一次" });
            }

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
                //new Claim(ClaimTypes.Gender, member.Gender),
                //new Claim(ClaimTypes.DateOfBirth, member.Birthday),
                //new Claim(ClaimTypes.HomePhone, member.PhoneNumber),
                //new Claim(ClaimTypes.MobilePhone, member.MobilePhone),
            };

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

        /// <summary>
        /// 會員註冊
        /// </summary>
        /// <param name="model">註冊所需資訊</param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                if (model == null
                    || _context.Members.Any(u => u.Account == model.Account)
                    || _context.Members.Any(u => u.Email == model.Email)
                    || !ModelState.IsValid)
                    return BadRequest(new { success = false, message = "錯誤，請再試一次" });

                _context.Members.Add(new Member
                {
                    Account = model.Account,
                    // Hash the password
                    // Install-Package BCrypt.Net-Next
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    VerificationToken = BCrypt.Net.BCrypt.GenerateSalt(),
                    Name = model.Name,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    Email = model.Email,
                    EmailComfirmed = false,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    MobilePhone = model.MobilePhone,
                    MemberShip = MemberShipType.NormalUser,
                    //LockOutEnabled = false,
                    //AccessFailedCount = 0,
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("Login");
        }

        /// <summary>
        /// 登出會員帳號，同時清除 Session
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            if (HttpContext.Session != null)
                HttpContext.Session.Clear();    // 清除 Session

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Account Details 頁面入口
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        //[Authorize]
        public IActionResult MyAccount()
        {
            return View();
        }

        // TODO 收取提交表單資料,並寫入會員資料庫
        /// <summary>
        /// Account Details 頁面「更改會員資訊」
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyAccount([FromBody] AccountDetailsModel model)
        {
            if (User.Identity?.IsAuthenticated == false || ModelState.IsValid == false)
                return BadRequest(new { success = false, message = "錯誤，請恰管理員" });

            // TODO 管理角色
            //var model = new MemberModel();
            //model.MemberId = User.Claims.GetMemberId();
            //model.Name = User.Identity.Name;
            //model.RememberMe = User.Claims.GetRememberMeStatus();
            //return View(model);

            var member = _context.Members
                .FirstOrDefault(m => m.MemberId == User.Claims.GetMemberId());
            var NewVerificationToken = BCrypt.Net.BCrypt.GenerateSalt();

            if (member == null || member.EmailComfirmed == true || String.IsNullOrEmpty(NewVerificationToken))
                return BadRequest(new { success = false, message = "錯誤，請恰管理員" });

            member.Name = $"{model.LastName}+{model.FirstName}";
            member.Email = model.Email;
            member.VerificationToken = NewVerificationToken;
            member.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPwd, NewVerificationToken);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyAccount));
        }

        /// <summary>
        /// 會員登入頁面的「忘記密碼」功能
        /// </summary>
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [ActionName("ForgetPassword")]
        [HttpPost]
        public async Task<IActionResult> ForgetPasswordAsync([FromBody] ForgetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "錯誤，請恰管理員" });
            }
            //// 檢查用戶是否存在?
            var thisUser = _context.Members
                        .Any(m => m.Account == model.Account
                        && m.Email == model.Email);
            if (thisUser == false)
            {
                // 如果找不到用戶, 丟出錯誤顯示
                ModelState.AddModelError("", "重置錯誤!");
                return BadRequest(new { success = false, message = GetErrorMessages() });
            }

            // 產生重置密碼 token
            string email = model.Email;
            string token = await GenerateTokenWithEmailAsync(email);

            if (String.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "重置錯誤，請聯繫管理員!");
                return BadRequest(new { success = false, message = GetErrorMessages() });
            }

            // 寄送重置密碼連結
            SendPasswordResetEmail(token, model.Email);

            return Ok(new { success = false, message = "已寄送重置密碼郵件通知!" });
        }

        /// <summary>
        /// Account Details 中的更換密碼功能
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ActionName("ResetPassword")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return BadRequest(new { success = false, message = "重設密碼錯誤，請聯繫管理員!" });

                var member = _context.Members.FirstOrDefaultAsync(t => t.MemberId == User.Claims.GetMemberId()).Result;

                if (member == null || member.EmailComfirmed == false)
                    return BadRequest(new { success = false, message = "重設密碼錯誤，請聯繫管理員!" });

                // 產生新密碼,更新回資料庫
                var verificationToken = BCrypt.Net.BCrypt.GenerateSalt();
                var token = BCrypt.Net.BCrypt.HashPassword(member.Email, verificationToken);
                member.Password = token;
                member.VerificationToken = verificationToken;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(new { success = true, message = "Successfully Reset Password" });
        }

        /// <summary>
        /// 開通帳號
        /// </summary>
        /// <returns></returns>
        public IActionResult Activate()
        {
            return View();
        }

        /// <summary>
        /// 開通帳號
        /// </summary>
        /// <returns></returns>
        [ActionName("Activate")]
        [HttpPost]
        public async Task<IActionResult> ActivateAsync(string token, string email)
        {
            // TODO 解開 Token (email + token)
            bool IsValid = BCrypt.Net.BCrypt.EnhancedVerify(email, token);
            if (IsValid == false) return BadRequest();

            // IsMemberExisted
            Member? user = await _context.Members
                .SingleOrDefaultAsync(u => u.VerificationToken == token);

            if (user == null) return NotFound();

            user.EmailComfirmed = true;
            user.VerificationToken = null;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 產生 Token (無需會員輸入版本)
        /// </summary>
        /// <param name="HasUser"></param>
        /// <returns></returns>
        private async Task<String> GenerateTokenWithEmailAsync(string email)
        {
            var verificationToken = BCrypt.Net.BCrypt.GenerateSalt();
            var token = BCrypt.Net.BCrypt.HashPassword(email, verificationToken);
            var member = _context.Members.FirstOrDefaultAsync(m => m.Email == email).Result;

            if (String.IsNullOrEmpty(email)
                || String.IsNullOrEmpty(token)
                || member == null)
                return String.Empty;

            member.Email = email;
            member.VerificationToken = verificationToken;
            member.EmailComfirmed = false;

            await _context.SaveChangesAsync();

            return token.ToString();
        }

        // TODO：帶入參數需調整
        /// <summary>
        /// 寄送郵件
        /// </summary>
        /// <param name="token"></param>
        private void SendPasswordResetEmail(string token, string email)
        {
            if (email == null) return;

            string reqestUrl = HttpContext.Request.GetEncodedUrl();
            reqestUrl = HttpUtility.UrlEncodeUnicode($"{reqestUrl}/{token}+{email}");
            Uri baseUrl = new Uri(reqestUrl);
            try
            {
                var mail = new MailMessage();
                mail.Subject = "您好！";
                mail.SubjectEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                mail.Body = $"<h4>請點擊下述連結，重置密碼<hr/> <h1>{baseUrl}</h1><br/><hr/></h4>";
                mail.From = new MailAddress("liang.case@gmail.com");
                mail.To.Add(new MailAddress(String.IsNullOrEmpty(email) ? email : "liang.case@me.com"));

                using (var client = new SmtpClient())
                {
                    var SmtpAccessToken = _configuration.GetValue<string>("SMTPConnection:GmailSMTP");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("liang.case@gmail.com", SmtpAccessToken);
                    client.Send(mail);  // 寄信
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SendConfirmationEmail(string email, string subject, string link)
        {
            using (var smtpClient = new SmtpClient())
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@example.com"),
                    To = { email },
                    Subject = subject,
                    Body = $"<h3>感謝您註冊，請點擊下述連結，請至您的信箱收取確認信！</h3><br/><a href='{link}'>{link}</a>",
                    IsBodyHtml = true
                };

                smtpClient.Send(mailMessage);
            }
        }

        /// <summary>
        /// 取得 ModelState 錯誤
        /// </summary>
        /// <returns></returns>
        private List<string> GetErrorMessages()
        {
            var errors = new List<string>();
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return errors;
        }
=======
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
<<<<<<< HEAD
>>>>>>> [新增] 自訂會員註冊控制器與登入畫面與 Member 表，修正 _Layout 連結
=======

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
<<<<<<< HEAD
>>>>>>> [更新加入] 會員 Member/MemberRole 資料內容類別表定義
=======

        // GET  /Member/MyAccount
        /// <summary>
        /// My Account 檢視頁面入口
        /// </summary>
        /// <param name="MemberId"></param>
        /// <returns></returns>
        public IActionResult MyAccount(int MemberId)    // TODO 如何找到會員 ID/Role/Name?
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().ValueType;
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
>>>>>>> [更新] 將會員資訊頁併入 Member 控制器與檢視, 調整 _Layout 連結, 顯示會員資訊以及修改功能需要補齊
    }
}