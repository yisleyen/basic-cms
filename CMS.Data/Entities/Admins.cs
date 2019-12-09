using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("Admins")]
    public class Admins
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }

        [Column("name", TypeName = "nvarchar")]
        [MaxLength(100)]
        [Required]
        public string name { get; set; }

        [Column("surname", TypeName = "nvarchar")]
        [MaxLength(100)]
        [Required]
        public string surname { get; set; }

        [Column("email", TypeName = "nvarchar")]
        [MaxLength(255)]
        [Required]
        public string email { get; set; }

        [Column("password", TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string password { get; set; }

        [Column("authority", TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string authority { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
