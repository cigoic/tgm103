using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// 下定日期
        /// </summary>
        public string OrderDate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public string ShippingDate { get; set; }

        /// <summary>
        /// 出貨狀態
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
    }
}