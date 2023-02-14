using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("CheckOuts")]
    public class CheckOut
    {
        /// <summary>
        /// 確認商品頁 ID (Primary Key , 自動編號)
        /// </summary>
        [Key]
        public int CheckOutId { get; set; }

        /// <summary>
        /// 收件人，最大長度 24
        /// </summary>
        [Required]
        [MaxLength(24)]
        public string Recipient { get; set; }

        /// <summary>
        /// 收件地址，最大長度 100
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收件人電話
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 優惠券
        /// </summary>
        public decimal? Coupon { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [Required]
        public GetPayType Type { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}