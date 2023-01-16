<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
using static WuliKaWu.Data.Enums.Common;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> test (#3)

namespace WuliKaWu.Models.ApiModel
{
    public class ProductModel
    {

<<<<<<< HEAD
        public string ProductName { get; set; }

        public List<int> Color { get; set; }

        public List<int> Size { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public string SellingPrice { get; set; }

        public List<IFormFile> PictureFiles { get; set; }
        public List<int> Tag { get; set; }
        public string Comment { get; set; }
    }
}
=======
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public int Price { get; set; }
        public string ImagePath { get; set; }
        public bool Discount { get; set; }
        public string SellingPrice { get; set; }

    }
}
>>>>>>> test (#3)
