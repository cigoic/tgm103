using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("StarRate")]
    public class TableOfStarRate
    {
        /// <summary>
        /// 星等ID(Primary Key)
        /// </summary>
        [Key]
        public int StarRateId { get; set; }

        /// <summary>
        /// 關聯的商品 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品的星等類型值
        /// </summary>
        public StarRate Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一商品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }
    }
}