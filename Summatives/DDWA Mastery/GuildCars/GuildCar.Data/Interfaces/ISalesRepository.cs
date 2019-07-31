using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Interfaces
{
    public interface ISalesRepository
    {
        IEnumerable<SalesReportRequest> GetSales();
        IEnumerable<SalesReportRequest> GetSalesSearchResults(SalesSearchParameters parameters);
        IEnumerable<Sales> GetAllSales();
        void InsertSale(Sales sale);
    }
}
