using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Category")]
    public class TableOfCategory
    {
        /// <summary>
        /// 商品分類 ID (Primary Key)
        /// </summary>
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// 關聯的商品 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品分類類型值
        /// </summary>
        public Category Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一產品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }
    }
}