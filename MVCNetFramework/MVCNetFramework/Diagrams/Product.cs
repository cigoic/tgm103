<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
=======
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 更新類別圖
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

<<<<<<< HEAD
namespace MVCNetFramework
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
namespace WuliKaWu.Data
>>>>>>> 更新類別圖
{
    [Table("Products")]
    public class Product
    {
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
=======
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> 更新類別圖
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
        public string Picture { get; set; }

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? discount { get; set; }

        public string? Comment { get; set; }

        public StarRate? StarRate { get; set; }

        public Category Category { get; set; }

        public Tag? Tag { get; set; }
=======
        public byte[] Picture { get; set; }
=======
        public string Picture { get; set; }
>>>>>>> 更新類別圖

        public decimal Price { get; set; }

        public decimal? SellingPrice { get; set; }

        public decimal? discount { get; set; }

        public string? Comment { get; set; }

        public StarRate? StarRate { get; set; }

        public Category Category { get; set; }

<<<<<<< HEAD
    public enum Tag
    {
        Hot, New, Spring, Winter
>>>>>>> [更新] Identity Login/Register 頁面套版，並加入自訂欄位，但輸入框需調整大小
=======
        public Tag? Tag { get; set; }
>>>>>>> 更新類別圖
    }
}