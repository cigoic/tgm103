using Microsoft.AspNetCore.Mvc;

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
    }
}