using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Pictures")]
    public class Picture
    {
        /// <summary>
        /// 商品圖片 ID (Primary Key, 自動編號)
        /// </summary>
        [Key]
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
>>>>>>> [新增] 商品圖片表並且在商品表加上商品圖片導覽屬性
=======
>>>>>>> [更新] 移除資料內容類別中自動編號的 DataAnnotation 敘述
        public int PictureId { get; set; }

        /// <summary>
        /// 關聯的商品 ID (Foreign Key)
        /// </summary>
        [ForeignKey("Products")]
        public int ProductId { get; set; }

        /// <summary>
        /// 商品圖片路徑，最大 nvarchar(max)
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 導覽屬性：只對應到單一商品，不用 ICollection
        /// </summary>
        public virtual Product Product { get; set; }
    }
}