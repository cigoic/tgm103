using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WuliKaWu.Data.Enums.Common;

namespace WuliKaWu.Data
{
    [Table("GetPayType")]
    public class TableOfGetPayType

    {
        [Key]
        public int GetPayTypeId { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        public GetPayType Type { get; set; }

        public virtual Order Order { get; set; }
    }
}