using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Models.ApiModel
{
    public class WishListGetAllModel
    {
        public int WishListId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public string PicturePath { get; set; }
        public int ProductId { get; set; }
        public int MemberId { get; set; }
    }
}