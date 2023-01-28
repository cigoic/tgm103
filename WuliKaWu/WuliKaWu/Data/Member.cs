using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Members")]
    public class Member //: IdentityUser<int>
    {
        /// <summary>
        /// 註冊會員 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        /// <summary>
        /// 註冊會員帳號，最大長度 16
        /// </summary>
        [MaxLength(16)]
        public string Account { get; set; }

        /// <summary>
        /// 註冊會員密碼，最大 nvarchar(max)
        /// </summary>
        public string Password { get; set; }

        //[ForeignKey("MemberRole")]
        //public string RoleId { get; set; }

        /// <summary>
        /// 註冊會員姓名，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Name { get; set; }

        /// <summary>
        /// 註冊會員性別（男/女）
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 註冊會員出生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 註冊會員電子信箱
        /// </summary>
        [MaxLength(256)]
        public string Email { get; set; }

        /// <summary>
        /// 通過信箱驗證與否
        /// </summary>
        public bool EmailComfirmed { get; set; }

        /// <summary>
        /// 註冊會員住址
        /// </summary>
        [MaxLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// 註冊會員（市內）聯絡電話
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 註冊會員行動電話
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 註冊會員等級
        /// </summary>
        public MemberShipType MemberShip { get; set; }

        /// <summary>
        /// 鎖住帳號登入功能啟用與否
        /// </summary>
        public bool LockOutEnabled { get; set; }

        /// <summary>
        /// 登入失敗次數
        /// </summary>
        public int AccessFailedCount { get; set; }


        /// <summary>
        /// 帳號角色
        /// </summary>
        public virtual ICollection<MemberRole> Roles { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多筆訂單，使用 ICollection
        /// </summary>
        public virtual ICollection<Order>? Orders { get; set; }

        /// <summary>
        /// 導覽屬性:對應到多筆聯絡訊息，使用 ICollection
        /// </summary>
        public virtual ICollection<ContactMessage?> ContactMessages { get; set; }

        public virtual ICollection<Article>? Articles { get; set; }
    }

    public enum MemberShipType
    {
        None, NormalUser, VIP, Admin
    }
}