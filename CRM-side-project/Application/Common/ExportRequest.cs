using CRM_side_project.DAL.Repository.Common;
using CRM_side_project.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_side_project.Application.Common
{
    public class ExportRequest
    {
        public Filter WhereCondition { get; set; } = new Filter();
        public Ordering Order { get; set; } = new Ordering();
        //public List<T> data { get; set; }

        public ExportSearching ToExportSearching()
        {
            return new ExportSearching
            {
                Order = new ExportSearching.Ordering
                {
                    Column = this.Order.Column,
                    IsOrderByDescending = this.Order.IsOrderByDescending,
                },
                WhereCondition = new ExportSearching.Filter
                {
                    TimeColumn = this.WhereCondition.TimeColumn,
                    StartDateTime = this.WhereCondition.StartDateTime.ToUnixTimeSeconds(),
                    EndDateTime = this.WhereCondition.EndDateTime.ToUnixTimeSeconds(),
                    Keyword = this.WhereCondition.Keyword,
                },
                
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
