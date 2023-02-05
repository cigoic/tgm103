using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Tag")]
    public class Tag
    {
        /// <summary>
        /// 商品標籤ID (Primary Key)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 商品標籤類型值
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一商品，不用 ICollection
        /// </summary>
        public virtual ICollection<Product> Product { get; set; }
    }
}
