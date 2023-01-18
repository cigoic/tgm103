using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? discount { get; set; }

        public string? Comment { get; set; }

        public StarRate? StarRate { get; set; }

        public Category Category { get; set; }

        public Tag? Tag { get; set; }
    }
}