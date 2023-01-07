using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WuliKaWu.Models;

namespace WuliKaWu.ViewModels
{
    //註冊用ViewModel
    public class MembersRegisterViewModel
    {
        public Members newMember { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        [DisplayName("確認密碼")]
        [Compare("Password", ErrorMessage = "兩次密碼輸入不一致")]
        [Required(ErrorMessage = "請輸入確認密碼")]
        public string PasswordCheck { get; set; }

    }
}