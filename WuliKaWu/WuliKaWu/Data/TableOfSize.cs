using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Size")]
    public class TableOfSize
    {
        /// <summary>
        /// 商品尺寸ID (Primary Key)
        /// </summary>
        [Key]
        public int SizeId { get; set; }

        /// <summary>
        /// 關聯的商品 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品尺寸類型值
        /// </summary>
        public Size Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一商品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }
    }
}