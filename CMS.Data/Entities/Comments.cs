using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }

        [Column("blogid", TypeName = "int")]
        public int? blogid { get; set; }

        [Column("name", TypeName = "nvarchar")]
        [MaxLength(250)]
        public string name { get; set; }

        [Column("email", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string email { get; set; }

        [Column("comment", TypeName = "nvarchar")]
        [MaxLength]
        public string comment { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
