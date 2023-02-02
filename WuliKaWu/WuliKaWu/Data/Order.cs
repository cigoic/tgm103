using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Orders")]
    public class Order
    {
        /// <summary>
        /// 訂單 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        /// <summary>
        /// 優惠券
        /// </summary>
        public decimal? Coupon { get; set; }

        /// <summary>
        /// 收件人，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Recipient { get; set; }

        /// <summary>
        /// 收件地址，最大長度 100
        /// </summary>
        [MaxLength(100)]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收件人電話
        /// </summary>
        [MaxLength(20)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public GetPayType Type { get; set; }

        /// <summary>
        /// 下定日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public DateTime ShippingDate { get; set; }

        /// <summary>
        /// 出貨狀態
        /// </summary>
        public ShippingStatus Status { get; set; }

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

        /// <summary>
        /// 導覽屬性：對應到多筆訂單明細，用 ICollection
        /// </summary>
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public enum ShippingStatus
    {
        [Description("待出貨")]
        WaittingToShip,

        [Description("出貨中")]
        Shipping,

        [Description("已送達")]
        Arrived
    }
}