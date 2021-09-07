using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.DAL.Repository.Models
{
    public class ExportProduct
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public byte UpdatedTimes { get; set; }
        public string UpdatedDateTime { get; set; }
        public string UpdatedUser { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Rowversion { get; set; }
    }
}
