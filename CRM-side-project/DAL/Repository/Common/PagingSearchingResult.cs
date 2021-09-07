using System.Collections.Generic;

namespace CRM_side_project.DAL.Repository.Common
{
    public class PagingSearchingResult<TResult>
    {
        public int TotalCount { get; set; }

        public IEnumerable<TResult> Data { get; set; }
    }
}