using System.Collections.Generic;

namespace CRM_side_project.DAL.Repository.Common
{
    public class PagingSearching
    {
        public Filter WhereCondition { get; set; }
        public Ordering Order { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }

        public PagingSearchingResult<TResult> ToPagingSearchingResult<TResult>(IEnumerable<TResult> data, int totalCount)
        {
            return new PagingSearchingResult<TResult>
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