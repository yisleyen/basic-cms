using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("Blogs")]
    public class Blogs
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }

        [Column("title", TypeName = "nvarchar")]
        [MaxLength(250)]
        [Required]
        public string title { get; set; }

        [Column("description", TypeName = "nvarchar")]
        [MaxLength]
        public string description { get; set; }

        [Column("imageUrl", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string imageUrl { get; set; }

        [Column("categoryid", TypeName = "int")]
        public int? categoryid { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
