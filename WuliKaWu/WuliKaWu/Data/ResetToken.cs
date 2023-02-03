using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("ResetTokens")]
    public class ResetToken
    {
        /// <summary>
        /// 重置密碼 Token ID 編號
        /// </summary>
        [Key]
        public int Id { get; set; }

<<<<<<< HEAD
        [ForeignKey("Members")]
        public int MemberId { get; set; }

=======
>>>>>>> [更新] 會員忘記密碼, 寄送驗證信功能與檢視頁面
        /// <summary>
        /// 寄送重置密碼的會員信箱
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 重置密碼 Token
        /// </summary>
        [Required]
        public Guid Token { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [Required]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 有效狀態: 失效_0, 有效_1
        /// </summary>
        [Required]
        public bool ValidateSatus { get; set; }
<<<<<<< HEAD

        /// <summary>
        /// 導覽屬性: 會員
        /// </summary>
        public virtual Member Member { get; set; }
=======
>>>>>>> [更新] 會員忘記密碼, 寄送驗證信功能與檢視頁面
    }
}