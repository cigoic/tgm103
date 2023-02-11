﻿namespace WuliKaWu.Models.ApiModel
{
    public class HomeTopNProductsModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? SellingPrice { get; set; }
        public bool Discount { get; set; }
        public IEnumerable<string> Pictures { get; set; }
    }
}