<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 暫時修改
=======
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> DB修改

namespace WuliKaWu.Data
{
    [Table("Category")]
    public class Category
    {
        /// <summary>
        /// 商品分類 ID (Primary Key)
        /// </summary>
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// 商品分類類型值
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 導覽屬性：對應到多個產品
        /// </summary>
        public virtual ICollection<Product> Product { get; set; }
    }
}