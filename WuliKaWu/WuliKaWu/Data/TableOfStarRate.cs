using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("StarRate")]
    public class TableOfStarRate
    {
        [Key]
        public int StarRateId { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }

        public StarRate Type { get; set; }

        public virtual Product Product { get; set; }
    }
}