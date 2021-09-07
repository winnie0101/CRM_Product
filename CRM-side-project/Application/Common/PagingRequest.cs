using CRM_side_project.DAL.Repository.Common;
using CRM_side_project.Utility.Extensions;
using System;

namespace CRM_side_project.Application.Common
{
    public class PagingRequest
    {
        public Filter WhereCondition { get; set; } = new Filter();
        public Ordering Order { get; set; } = new Ordering();
        public int PageOffset { get; set; }
        public int PageSize { get; set; }

        public PagingSearching ToPagingSearching()
        {
            return new PagingSearching
            {
                Order = new PagingSearching.Ordering
                {
                    Column = this.Order.Column,
                    IsOrderByDescending = this.Order.IsOrderByDescending,
                },
                WhereCondition = new PagingSearching.Filter
                {
                    TimeColumn = this.WhereCondition.TimeColumn,
                    StartDateTime = this.WhereCondition.StartDateTime.ToUnixTimeSeconds(),
                    EndDateTime = this.WhereCondition.EndDateTime.ToUnixTimeSeconds(),
                    Keyword = this.WhereCondition.Keyword,
                },
                Skip = this.PageOffset * this.PageSize,
                Take = this.PageSize
            };
        }

        public class Filter
        {
            public string TimeColumn { get; set; }
            public DateTime? StartDateTime { get; set; }
            public DateTime? EndDateTime { get; set; }
            public string Keyword { get; set; }
        }

        public class Ordering
        {
            public bool IsOrderByDescending { get; set; } = true;

            public string Column { get; set; }
        }
    }
}