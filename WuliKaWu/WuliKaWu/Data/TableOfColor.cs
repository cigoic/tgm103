using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Color")]
    public class TableOfColor
    {
        [Key]
        public int ColorId { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public Color Type { get; set; }

        public virtual Product Product { get; set; }
    }
}