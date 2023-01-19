using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Size")]
    public class TableOfSize
    {
        [Key]
        public int SizeId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Size Type { get; set; }

        public virtual Product Product { get; set; }
    }
}