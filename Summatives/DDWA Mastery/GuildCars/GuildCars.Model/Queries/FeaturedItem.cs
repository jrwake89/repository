using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class FeaturedVehicleItem
    {
        public int Year { get; set; }
        public int vehicleId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal SalesPrice { get; set; }
        public string PictureFileName { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
