using System.ComponentModel.DataAnnotations;
using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class OrderApiModel
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }

        /// <summary>
        /// 下定日期
        /// </summary>
        public string OrderDate { get; set; }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public string ShippingDate { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public int GetPayTypeId { get; set; }

        public string GetPayType { get; set; }
        /// <summary>
        /// 出貨狀態
        /// </summary>

        public int StatusId { get; set; }

        public string StatusType { get; set; }

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
        /// 備註
        /// </summary>
        public string? Memo { get; set; }
    }
}