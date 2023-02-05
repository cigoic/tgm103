using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Category")]
    public class Category
    {
        /// <summary>
        /// 商品分類 ID (Primary Key)
        /// </summary>
        [Key]
        public int CategoryId { get; set; }
        /// <summary>
        /// 商品分類類型值
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一產品，不用 ICollection
        /// </summary>
        public virtual ICollection<Product> Product { get; set; }
    }
}
