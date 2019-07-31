using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class VehicleDetailsRequest
    {
        public int VehicleId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ColorType { get; set; }
        public string TransmitionType { get; set; }
        public string InteriorType { get; set; }
        public decimal Mileage { get; set; }
        public string VinNum { get; set; }
        public int Year { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string PictureFileName { get; set; }
        public string BodyStyle { get; set; }
        public string Descrip { get; set; }
        public bool IsNew { get; set; }
        public bool IsSold { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public VehicleSearchParameters parameters { get; set; }

    }
}
