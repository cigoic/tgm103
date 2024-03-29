﻿using System.ComponentModel;
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
        public int MemberId { get; set; }

        /// <summary>
        /// 註冊會員帳號，最大長度 16
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string Account { get; set; }

        /// <summary>
        /// 註冊會員密碼，最大 nvarchar(max)
        /// </summary>
        [Required]
        public string Password { get; set; }

        public string? VerificationToken { get; set; }

        /// <summary>
        /// 註冊會員姓名，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Name { get; set; }

        /// <summary>
        /// 註冊會員性別（0:女/1:男）
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
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 註冊會員行動電話
        /// </summary>
        [MaxLength(20)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 註冊會員等級
        /// </summary>
        public MemberShipType MemberShip { get; set; }

        /// <summary>
        /// 鎖住帳號登入功能啟用與否
        /// </summary>
        //public bool LockOutEnabled { get; set; }

        /// <summary>
        /// 登入失敗次數
        /// </summary>
        //public int AccessFailedCount { get; set; }

        /// <summary>
        /// 帳號角色
        /// </summary>
        public virtual ICollection<MemberRole> Roles { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多筆 Reset Tokens，使用 ICollection
        /// </summary>
        public virtual ICollection<ResetToken> ResetTokens { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多筆訂單，使用 ICollection
        /// </summary>
        public virtual ICollection<Order>? Orders { get; set; }

        /// <summary>
        /// 導覽屬性:對應到多筆確認訂單,使用 ICollection
        /// </summary>
        public virtual ICollection<CheckOut>? CheckOuts { get; set; }

        /// <summary>
        /// 導覽屬性:對應到多筆聯絡訊息，使用 ICollection
        /// </summary>
        public virtual ICollection<ContactMessage?> ContactMessages { get; set; }

        /// <summary>
        /// 導覽屬性:對應多筆部落格文章，使用 ICollection
        /// </summary>
        public virtual ICollection<Article>? Articles { get; set; }

        /// <summary>
        /// 導覽屬性:對應多個購物車，使用 ICollection
        /// </summary>
        public virtual ICollection<Cart> Cart { get; set; }

        /// <summary>
        /// 導覽屬性:對應多個收藏清單，使用 ICollection
        /// </summary>
        public virtual ICollection<WishList> WishList { get; set; }
    }

    public enum MemberShipType
    {
        [Description("None")]
        None,

        [Description("NormalUser")]
        NormalUser,

        [Description("VIP")]
        VIP,

        [Description("Admin")]
        Admin
    }
}