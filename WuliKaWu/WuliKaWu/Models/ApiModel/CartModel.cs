using WuliKaWu.Data;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Models.ApiModel
{
    public class CartModel
    {
        public int CartId { get; set; }
        public Product Product { get; set; }
    }
}