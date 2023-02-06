using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class EditModel
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        public int ProductId { get; set; }
=======

>>>>>>> [修改]Edit頁面部分欄位完成(仍有一部分有誤)

>>>>>>> [更新]將商品編輯的檢視改為用Vue(點擊儲存編輯的功能尚未完成)
=======
>>>>>>> [新增]CategoriesController Action的Create及Edit
        public string ProductName { get; set; }

        public Color Color { get; set; }

        public string Size { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
        public string Category { get; set; }
=======
        public Category Category { get; set; }
>>>>>>> [更新]將商品編輯的檢視改為用Vue(點擊儲存編輯的功能尚未完成)
=======
        public string Category { get; set; }
>>>>>>> [新增]CategoriesController Action的Create及Edit

        public string PicturePath { get; set; }

        public decimal Price { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
        public bool? Discount { get; set; }

        public string? SellingPrice { get; set; }

        public Tag? Tag { get; set; }
=======
        public bool Discount { get; set; }
=======
        public bool? Discount { get; set; }
>>>>>>> [修正]EditModel及PreviewModel的部分型態可為null

        public string? SellingPrice { get; set; }

<<<<<<< HEAD
        public Tag Tag { get; set; }
>>>>>>> [更新]將商品編輯的檢視改為用Vue(點擊儲存編輯的功能尚未完成)
=======
        public Tag? Tag { get; set; }
>>>>>>> [修正]EditModel及PreviewModel的部分型態可為null
    }
}