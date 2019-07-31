using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class SearchResultsRequest
    {
        public int VehicleId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int TransmitionId { get; set; }
        public int InteriorId { get; set; }
        public int Mileage { get; set; }
        public int VinNum { get; set; }
        public int Year { get; set; }
        public string Descrip { get; set; }
        public int MSRP { get; set; }
        public int SalesPrice { get; set; }
        public string BodyStyle { get; set; }
        public string PictureFileName { get; set; }
        public bool IsSold { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
    }
}
