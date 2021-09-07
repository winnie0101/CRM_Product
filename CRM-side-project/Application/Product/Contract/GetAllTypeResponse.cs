using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Application.Product.Contract
{
    public class GetAllTypeResponse
    {
        public long TypeId { get; set; }
        public string TypeName { get; set; }
        public bool IsEnabled { get; set; }
        public long CreatedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public byte UpdatedTimes { get; set; }
        public long UpdatedDateTime { get; set; }
        public string UpdatedUser { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Rowversion { get; set; }
    }
}
