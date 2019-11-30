using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Data
{
    [Table("AboutUs")]
    public class AboutUs
    {
        [Key]
        [Column("id", TypeName = "int")]
        [Required]
        public int id { get; set; }

        [Column("description", TypeName = "nvarchar")]
        [MaxLength]
        public string description { get; set; }

        [Column("isactive", TypeName = "bit")]
        public bool? isactive { get; set; }

        [Column("createddate", TypeName = "datetime")]
        public DateTime? createddate { get; set; }

    }
}
