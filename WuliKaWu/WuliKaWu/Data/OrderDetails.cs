using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    //TODO OrderDetails名稱須更正,該怎麼更改並更新資料庫
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }

        /// <summary>
        /// 訂單 ID
        /// </summary>

        public int OrderId { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品顏色
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 商品尺寸
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 商品圖片位址
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一訂單，不用 ICollection
        /// </summary>
        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
    }
}