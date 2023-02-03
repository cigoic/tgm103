<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< HEAD
using static WuliKaWu.Data.Enums.Common;

=======
﻿using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model
using System.ComponentModel.DataAnnotations.Schema;
=======
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
using static WuliKaWu.Data.Enums.Common;

>>>>>>> [新增]所有資料表
namespace WuliKaWu.Data
{
    [Table("Orders")]
    public class Order
    {
<<<<<<< HEAD
<<<<<<< HEAD
        /// <summary>
        /// 訂單 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// 優惠券
        /// </summary>
        public decimal? Coupon { get; set; }

        /// <summary>
        /// 收件人，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Recipient { get; set; }

        /// <summary>
        /// 收件地址，最大長度 100
        /// </summary>
        [MaxLength(100)]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收件人電話
        /// </summary>
        [MaxLength(20)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public GetPayType Type { get; set; }

        /// <summary>
        /// 下定日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public DateTime ShippingDate { get; set; }

        /// <summary>
        /// 出貨狀態
        /// </summary>
        public ShippingStatus Status { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多筆訂單明細，用 ICollection
        /// </summary>
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public enum ShippingStatus
    {
        [Description("待出貨")]
        WaittingToShip,

        [Description("出貨中")]
        Shipping,

        [Description("已送達")]
        Arrived
=======
=======
        /// <summary>
        /// 訂單 ID (Primary Key, 自動編號)
        /// </summary>
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// 優惠券
        /// </summary>
        public decimal? Coupon { get; set; }

        /// <summary>
        /// 收件人，最大長度 24
        /// </summary>
        [MaxLength(24)]
        public string Recipient { get; set; }

        /// <summary>
        /// 收件地址，最大長度 100
        /// </summary>
        [MaxLength(100)]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收件人電話
        /// </summary>
        [MaxLength(20)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public GetPayType Type { get; set; }

        /// <summary>
        /// 下定日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public DateTime ShippingDate { get; set; }

        /// <summary>
        /// 出貨狀態
        /// </summary>
        public ShippingStatus Status { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string? Memo { get; set; }

<<<<<<< HEAD
        public virtual ICollection<TableOfGetPayType> TableOfGetPayTypes { get; set; }
>>>>>>> [新增]所有資料表
=======
        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }
<<<<<<< HEAD
>>>>>>> [新增]OrderDetailsTable，[更新]Common表、Cart表、ContactMessage表、Member表、Order表加入Summary
=======

        /// <summary>
        /// 導覽屬性：對應到多筆訂單明細，用 ICollection
        /// </summary>
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public enum ShippingStatus
    {
        [Description("待出貨")]
        WaittingToShip,

        [Description("出貨中")]
        Shipping,

        [Description("已送達")]
        Arrived
>>>>>>> [更改]Cart,Member,Order,OrderDetails,Product,Wishlist 的Model
    }
}