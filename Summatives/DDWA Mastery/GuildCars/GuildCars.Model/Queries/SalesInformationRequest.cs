using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class SalesInformationRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public int PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
    }
}
