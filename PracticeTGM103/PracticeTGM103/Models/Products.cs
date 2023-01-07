using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models
{
    public enum StarRating
    {
        None = 0, Onestar = 1, Twostar = 2, Threestar = 3, Fourstar = 4, Fivestar = 5
    }

    public enum Color
    {
        Black = 0, Red = 1, Green = 2,
    }

    public enum Size
    {
        S = 1, M = 2, L = 3
    }

    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public string Item { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public byte[] Picture { get; set; }
        public int Price { get; set; }
        public string Comments { get; set; }
        public StarRating? StarRating { get; set; }
    }
}