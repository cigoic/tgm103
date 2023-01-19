using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Tag")]
    public class TableOfTag
    {
        [Key]
        public int TagId { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public Tag Type { get; set; }

        public virtual Product Product { get; set; }
    }
}