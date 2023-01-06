using System.ComponentModel.DataAnnotations;

namespace PracticeTGM103.Models.practice
{
    public class OrdersDemo
    {
        [Key]
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public int UnitPrice { get; set; }

        public float? Discount { get; set; }

        public string ShipAdress { get; set; }

        public enum GetPayType
        { Cash, CreditCard, MobilePay }

        public string? Memo { get; set; }

        public int TotalPrice { get; set; }
    }
}