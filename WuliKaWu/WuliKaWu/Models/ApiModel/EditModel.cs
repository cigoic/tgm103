using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class EditModel
    {
<<<<<<< HEAD
=======
        public int ProductId { get; set; }

>>>>>>> [更新]將商品編輯的檢視改為用Vue(點擊儲存編輯的功能尚未完成)
        public string ProductName { get; set; }

        public Color Color { get; set; }

        public string Size { get; set; }

<<<<<<< HEAD
        public string Category { get; set; }
=======
        public Category Category { get; set; }
>>>>>>> [更新]將商品編輯的檢視改為用Vue(點擊儲存編輯的功能尚未完成)

        public string PicturePath { get; set; }

        public decimal Price { get; set; }

<<<<<<< HEAD
        public bool? Discount { get; set; }

        public string? SellingPrice { get; set; }

        public Tag? Tag { get; set; }
=======
        public bool Discount { get; set; }

        public string SellingPrice { get; set; }

        public Tag Tag { get; set; }
>>>>>>> [更新]將商品編輯的檢視改為用Vue(點擊儲存編輯的功能尚未完成)
    }
}