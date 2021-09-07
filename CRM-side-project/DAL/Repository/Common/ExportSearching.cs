using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.DAL.Repository.Common
{
    public class ExportSearching
    {
        public Filter WhereCondition { get; set; }
        public Ordering Order { get; set; }

        public ExportSearchingResult<TResult> ToExportSearchingResult<TResult>(IEnumerable<TResult> data, int totalCount)
        {
            return new ExportSearchingResult<TResult>
            {
                Data = data,
                TotalCount = totalCount,
            };
        }

        public class Filter
        {
            public string TimeColumn { get; set; }
            public long? StartDateTime { get; set; }
            public long? EndDateTime { get; set; }
            public string Keyword { get; set; }
        }

        public class Ordering
        {
            public bool IsOrderByDescending { get; set; } = true;

            public string Column { get; set; }
        }
    }
}
