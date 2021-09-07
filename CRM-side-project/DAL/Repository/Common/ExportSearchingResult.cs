using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.DAL.Repository.Common
{
    public class ExportSearchingResult<TResult>
    {
        public int TotalCount { get; set; }

        public IEnumerable<TResult> Data { get; set; }
    }
}
