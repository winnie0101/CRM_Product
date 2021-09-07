using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CRM_side_project.Models
{
    [Table("ProductType")]
    public partial class ProductType
    {
        [Key]
        [Column("TypeID")]
        public long TypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
        public long CreatedDateTime { get; set; }
        [Required]
        [StringLength(100)]
        public string CreatedUser { get; set; }
        public byte UpdatedTimes { get; set; }
        public long UpdatedDateTime { get; set; }
        [Required]
        [StringLength(100)]
        public string UpdatedUser { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public byte[] Rowversion { get; set; }
    }
}
