using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class VehicleSearchParameters
    {
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public string search { get; set; }
        public int? minYear { get; set; }
        public int? maxYear { get; set; }

    }
}
