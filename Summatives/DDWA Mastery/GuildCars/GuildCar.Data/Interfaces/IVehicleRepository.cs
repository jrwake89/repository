using GuildCars.Model;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<FeaturedVehicleItem> GetFeatured();
        IEnumerable<VehicleDetailsRequest> GetSearchResults(VehicleSearchParameters parameters);
        IEnumerable<Color> GetAllColors();
        IEnumerable<Interior> GetAllInteriors();
        IEnumerable<Model> GetAllModels();
        IEnumerable<Make> GetAllMakes();
        VehicleDetailsRequest GetVehicleDetails(int vehicleId);
        Vehicle GetVehicle(int vehicleId);
        Model GetModelById(int modelId);
        Make GetMakeById(int makeId);
        IEnumerable<InventoryReportRequest> GetInventoryReport();
        void InsertContact(ContactUs contact);
        void InsertVehicle(Vehicle vehicle);
        void InsertMake(Make make);
        void InsertModel(Model model);
        void UpdateVehicle(Vehicle vehicle);

    }
}
