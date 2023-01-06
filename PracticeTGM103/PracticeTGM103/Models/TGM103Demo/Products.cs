using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models.Products
{
    public enum StarRating
    {
        onestar = 1, twostar = 2, threestar = 3, fourstar = 4, fivestar = 5
    }

    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public string Item { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public byte[] Picture { get; set; }
        public int Price { get; set; }
        public string Comments { get; set; }
        public StarRating? StarRating { get; set; }
    }
}