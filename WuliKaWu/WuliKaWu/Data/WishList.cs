﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("WishLists")]
    public class WishList
    {
        /// <summary>
        /// 願望清單ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishListId { get; set; }

        /// <summary>
        /// 關聯的會員ID (Foreign Key)
        /// </summary>
        [ForeignKey("Members")]
        public int MemberId { get; set; }

        /// <summary>
        /// 關聯的商品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 導覽屬性:只對應到單一個會員，不用 ICollection
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// 導覽屬性:對應多筆商品，使用 ICollection
        /// </summary>
        [ForeignKey("ProductId")]
        public virtual ICollection<Product> Products { get; set; }
    }
}