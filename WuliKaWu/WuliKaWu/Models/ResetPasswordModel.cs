namespace WuliKaWu.Models
{
    public class ResetPasswordModel
    {
        public string Password { get; set; }
        public Guid ResetToken { get; set; }
    }
}