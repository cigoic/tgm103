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

        public decimal? Discount { get; set; }

        public string? Comment { get; set; }

        public StarRate? StarRate { get; set; }

        public Category Category { get; set; }

        public Tag? Tag { get; set; }

        public virtual ICollection<TableOfSize> TableOfSizes { get; set; }

        public virtual ICollection<TableOfColor> TableOfColors { get; set; }

        public virtual ICollection<TableOfStarRate> TableOfStarRates { get; set; }

        public virtual ICollection<TableOfCategory> TableOfCategories { get; set; }

        public virtual ICollection<TableOfTag> TableOfTags { get; set; }
    }
}