using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("GetPayType")]
    public class TableOfGetPayType

    {
        /// <summary>
        /// 付款方式 ID (Primary Key)
        /// </summary>
        [Key]
        public int GetPayTypeId { get; set; }

        /// <summary>
        /// 關聯的訂單 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        /// <summary>
        /// 付款方式類型值
        /// </summary>
        public GetPayType Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一訂單，不用 ICollection
        /// </summary>
        public virtual Order Order { get; set; }
    }
}