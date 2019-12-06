using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }

        [Column("address", TypeName = "nvarchar")]
        [MaxLength]
        [Required]
        public string address { get; set; }

        [Column("phone", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string phone { get; set; }

        [Column("fax", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string fax { get; set; }

        [Column("email", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string email { get; set; }

        [Column("whatsapp", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string whatsapp { get; set; }

        [Column("facebook", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string facebook { get; set; }

        [Column("twitter", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string twitter { get; set; }

        [Column("instagram", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string instagram { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
