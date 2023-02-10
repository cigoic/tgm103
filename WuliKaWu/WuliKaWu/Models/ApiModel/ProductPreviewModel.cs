using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class ProductPreviewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Size Size { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public bool Discount { get; set; }

        public decimal? SellingPrice { get; set; }

        public int? StarRates { get; set; }

        public string? Comment { get; set; }

        public List<int>? Tags { get; set; }

        public List<int>? Colors { get; set; }

        public List<string>? Pictures { get; set; }
    }
}