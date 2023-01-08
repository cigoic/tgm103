using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public byte[] Picture { get; set; }

        public int Price { get; set; }

        public string? Comment { get; set; }

        public StarRate StarRate { get; set; }

        public Category Category { get; set; }

        public Tag? Tag { get; set; }

        public virtual ICollection<CartViewModel> Cart { get; set; }
    }

    public enum Color
    {
        Black = 0, Blue = 1, Brown = 2, Red = 3, Orange = 4
    }

    public enum Size
    {
        XS, S, M, L, XL
    }

    public enum StarRate
    {
        NoStar = 0, OneStar = 1, TwoStar = 2, ThreeStar = 3, FourStar = 4, FiveStar = 5
    }

    public enum Category
    {
        Tops, Buttoms, Outer, Dress
    }

    public enum Tag
    {
        Hot, New, Spring, Winter
    }
}