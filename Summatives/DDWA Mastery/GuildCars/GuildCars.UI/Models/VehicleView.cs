using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class VehicleView
    {
        public int VehicleId { get; set; }
        public string UserId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransmitionId { get; set; }
        public int InteriorId { get; set; }
        public string Mileage { get; set; }
        public string VinNum { get; set; }
        public string Year { get; set; }
        public string Descrip { get; set; }
        public string MSRP { get; set; }
        public string SalesPrice { get; set; }
        public string PictureFileName { get; set; }
        public bool IsSold { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
    }
}