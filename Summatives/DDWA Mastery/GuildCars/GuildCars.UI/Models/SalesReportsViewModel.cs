using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SalesReportsViewModel
    {
        public SalesReportsViewModel()
        {
            SalesReportRequest salesReport = new SalesReportRequest();
            UsersItem user = new UsersItem();
        }

        public string FromDateS { get; set; }
        public DateTime FromDate { get; set; }
        public string ToDateS { get; set; }
        public DateTime ToDate { get; set; }
        public IEnumerable<SalesReportRequest> salesReport { get; set; }
        public IEnumerable<UsersItem> users { get; set; }
    }
}