using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Color")]
    public class Color
    {
        /// <summary>
        /// 商品顏色 ID (Primary Key)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 商品顏色類型值
        /// </summary>
        public string Type { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
