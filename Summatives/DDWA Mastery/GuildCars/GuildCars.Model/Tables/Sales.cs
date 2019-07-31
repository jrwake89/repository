using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Tables
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int VehicleId { get; set; }
        public string BuyerName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int ZipCode { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string StateName { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime DatePurchased { get; set; }
        public string DatePurchasedString { get; set; }
        public string PurchaseType { get; set; }
        public string UserId { get; set; }
    }
}
