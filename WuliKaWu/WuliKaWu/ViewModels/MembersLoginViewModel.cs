using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WuliKaWu.ViewModels
{
    //登入用ViewModel
    public class MembersLoginViewModel
    {
        [DisplayName("會員帳號")]
        [Required(ErrorMessage = "請輸入會員帳號")]
        public string Account { get; set; }

        [DisplayName("會員密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

    }
}
