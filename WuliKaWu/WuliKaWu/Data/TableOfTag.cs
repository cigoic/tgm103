using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Tag")]
    public class TableOfTag
    {
        /// <summary>
        /// 商品標籤ID (Primary Key)
        /// </summary>
        [Key]
        public int TagId { get; set; }

        /// <summary>
        /// 關聯的商品 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品標籤類型值
        /// </summary>
        public Tag Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一商品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }
    }
}