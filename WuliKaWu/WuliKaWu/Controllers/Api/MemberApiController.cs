using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> [更新] 忘記密碼功能與改用 Vue.js 渲染
using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Net.Mail;
using System.Text;
<<<<<<< HEAD
=======
>>>>>>> [更新] 調整會員登入使用 ClaimsType.Sid, RoleType 使用 Description 描述, 以及登入頁面
=======
>>>>>>> [更新] 忘記密碼功能與改用 Vue.js 渲染

using WuliKaWu.Data;
using WuliKaWu.Models;

namespace WuliKaWu.Controllers.Api
{
    [Route("api/Member/{action}")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        private readonly ShopContext _context;

        public MemberApiController(ShopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public LoginMessage Login([FromForm] MemberLoginModel model)
        {
            // 資料庫比對
            var member = _context.Members
                            .SingleOrDefault(x => x.Account == model.Account);

            if (member == null || !BCrypt.Net.BCrypt.Verify(model.Password, member.Password))
            {
                return new LoginMessage
                {
                    Status = false,
                    Message = "帳號密碼不對！"
                };
            }

            return new LoginMessage
            {
                Status = true,
                Message = $"嗨! {User.Identity?.Name}"
            };
        }
<<<<<<< HEAD
<<<<<<< HEAD


=======
>>>>>>> [更新] 調整會員登入使用 ClaimsType.Sid, RoleType 使用 Description 描述, 以及登入頁面
=======


>>>>>>> [更新] 忘記密碼功能與改用 Vue.js 渲染
    }
}