using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WuliKaWu.Data
{
    [Table("Contact Messages")]
    public class ContactMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [StringLength(64)]
        public String Name { get; set; }

        [StringLength(64)]
        public String Email { get; set; }

        public String Subject { get; set; }

        [MaxLength(16)]
        [Column(TypeName = "nchar")]
        public String Phone { get; set; }

        [StringLength(256)]
        public String Message { get; set; }
    }
}