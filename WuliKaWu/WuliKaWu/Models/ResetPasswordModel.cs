namespace WuliKaWu.Models
{
    public class ResetPasswordModel
    {
        public string Password { get; set; }
<<<<<<< HEAD
        public string ResetToken { get; set; }
=======
        public Guid ResetToken { get; set; }
>>>>>>> [更新] 重置密碼功能, 加入 Reset Token 表格定義
    }
}