using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Application.Common
{
    public class ExportResponse<T>
    {
        public int code { get; set; }
        public string desc { get; set; }
        public T data { get; set; }
    }
}
