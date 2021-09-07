using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Application.Product.Contract
{
    public class CreateTypeRequest
    {
        [Required]
        public string TypeName { get; set; }
    }
}
