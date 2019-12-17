using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("SiteInfos")]
    public class SiteInfos
    {
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }

        [Column("title", TypeName = "nvarchar")]
        [MaxLength(150)]
        public string title { get; set; }

        [Column("keywords", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string keywords { get; set; }

        [Column("description", TypeName = "nvarchar")]
        [MaxLength]
        public string description { get; set; }

        [Column("logoUrl", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string logoUrl { get; set; }

        [Column("degree", TypeName = "nvarchar")]
        [MaxLength(255)]
        public string degree { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
