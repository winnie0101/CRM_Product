using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CRM_side_project.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column("ProductID")]
        public long ProductId { get; set; }
        [Required]
        [StringLength(80)]
        public string ProductName { get; set; }
        [Column("TypeID")]
        public long TypeId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public long CreatedDateTime { get; set; }
        [Required]
        [StringLength(50)]
        public string CreatedUser { get; set; }
        public byte UpdatedTimes { get; set; }
        public long UpdatedDateTime { get; set; }
        [Required]
        [StringLength(50)]
        public string UpdatedUser { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public byte[] Rowversion { get; set; }
    }
}
