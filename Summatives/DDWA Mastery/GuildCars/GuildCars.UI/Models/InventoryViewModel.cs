using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<InventoryReportRequest> UsedCars { get; set; }
        public IEnumerable<InventoryReportRequest> NewCars { get; set; }
    }
}