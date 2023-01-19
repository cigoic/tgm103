using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Category")]
    public class TableOfCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public Category Type { get; set; }

        public virtual Product Product { get; set; }
    }
}