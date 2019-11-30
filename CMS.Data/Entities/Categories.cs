using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Column("id", TypeName = "int")]
        [Required]
        public int id { get; set; }

        [Column("title", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string title { get; set; }

        [Column("description", TypeName = "nvarchar")]
        [MaxLength]
        public string description { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
