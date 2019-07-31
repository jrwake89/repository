using GuildCar.Data.Factory;
using GuildCars.Model;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.UI.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            specials = SpecialFactory.GetSpecialRepository().GetSpecials();
            featured = VehicleFactory.GetVehicleRepository().GetFeatured().Where(f => f.IsDeleted == false);
        }
       
        public IEnumerable<Special> specials { get; set; }
        public IEnumerable<FeaturedVehicleItem> featured { get; set; }
        public VehicleSearchParameters parameters { get; set; }
        public IEnumerable<VehicleDetailsRequest> vehicleDetails { get; set; }
    }
}
