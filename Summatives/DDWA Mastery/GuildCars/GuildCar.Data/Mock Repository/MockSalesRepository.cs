using GuildCar.Data.Interfaces;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Mock_Repository
{
    public class MockSalesRepository : ISalesRepository
    {
        private static List<Sales> _sales = new List<Sales>()
        {
            new Sales {SalesId = 1, VehicleId = 1, BuyerName = "John Doe", Email ="johndoe@gmail.com", Phone = "111-222-3333", Street1 = "101 Drive Street", Street2 = "202 Street Drive", DatePurchased = new DateTime(2019, 02, 01), City = "Louisville", StateName = "KY", PurchasePrice = 5000, PurchaseType = "Dealer Finance", UserId = "000000-0000-0000-0000-000000", ZipCode = 12345},
            new Sales {SalesId = 2, VehicleId = 2, BuyerName = "Jane Doe", Email ="janedoe@gmail.com", Phone = "111-222-4444", Street1 = "101 Drive Street", Street2 = "202 Street Drive", DatePurchased = new DateTime(2010, 01, 04), City = "Louisville", StateName = "KY", PurchasePrice = 6500, PurchaseType = "Dealer Finance", UserId = "000000-0000-0000-0000-000000", ZipCode = 12345},
            new Sales {SalesId = 3, VehicleId = 3, BuyerName = "Randy Smith", Email ="randysmith@gmail.com", Phone = "859-222-1234", Street1 = "222 Drive Street", Street2 = "345 Street Drive", DatePurchased = new DateTime(2019, 02, 01), City = "Louisville", StateName = "KY", PurchasePrice = 7000, PurchaseType = "Dealer Finance", UserId = "000000-0000-0000-0000-000000", ZipCode = 12345},
            new Sales {SalesId = 4, VehicleId = 4, BuyerName = "Carol Hart", Email ="carolhart@gmail.com", Phone = "859-333-2334", Street1 = "222 Lane Avenue", Street2 = "345 Street Drive", DatePurchased = new DateTime(2015, 02, 01), City = "Louisville", StateName = "KY", PurchasePrice = 8000, PurchaseType = "Cash", UserId = "000000-0000-0000-0000-000000", ZipCode = 67856}
        };

        private static List<User> _users = new List<User>()
        {

                        new User {UserName = "admin@test.com", Email = "admin@test.com", FirstName = "Joshua", LastName = "Wakefield", UserId = "71a7365f-de86-485d-9b09-443e5ee71394"},
                        new User {UserName = "debbiekeene@test.com", Email = "debbiekeene@test.com", FirstName = "Debbie", LastName = "Keene", UserId = "8f29ed26-d50d-4a82-9b94-151d4699f9ad"},
                        new User {UserName = "unittestuser@test.com", Email = "unittestuser@teset.com", FirstName = "Rad", LastName = "Joes", UserId = "000000-0000-0000-0000-000000" }

        };

        public void ResetSalesRepository()
        {
            _users = new List<User>()
            {
                new User {UserName = "admin@test.com", Email = "admin@test.com", FirstName = "Joshua", LastName = "Wakefield", UserId = "71a7365f-de86-485d-9b09-443e5ee71394"},
                new User {UserName = "debbiekeene@test.com", Email = "debbiekeene@test.com", FirstName = "Debbie", LastName = "Keene", UserId = "8f29ed26-d50d-4a82-9b94-151d4699f9ad"},
                new User {UserName = "unittestuser@test.com", Email = "unittestuser@teset.com", FirstName = "Rad", LastName = "Joes", UserId = "000000-0000-0000-0000-000000" }
            };

            _sales = new List<Sales>()
            {
                new Sales {SalesId = 1, VehicleId = 1, BuyerName = "John Doe", Email ="johndoe@gmail.com", Phone = "111-222-3333", Street1 = "101 Drive Street", Street2 = "202 Street Drive", DatePurchased = new DateTime(2019, 02, 01), StateName = "KY", PurchasePrice = 5000, PurchaseType = "Dealer Finance", UserId = "000000-0000-0000-0000-000000", ZipCode = 12345},
                new Sales {SalesId = 2, VehicleId = 2, BuyerName = "Jane Doe", Email ="janedoe@gmail.com", Phone = "111-222-4444", Street1 = "101 Drive Street", Street2 = "202 Street Drive", DatePurchased = new DateTime(2010, 02, 01), StateName = "KY", PurchasePrice = 6500, PurchaseType = "Dealer Finance", UserId = "000000-0000-0000-0000-000000", ZipCode = 12345},
                new Sales {SalesId = 3, VehicleId = 3, BuyerName = "Randy Smith", Email ="randysmith@gmail.com", Phone = "859-222-1234", Street1 = "222 Drive Street", Street2 = "345 Street Drive", DatePurchased = new DateTime(2019, 02, 01), StateName = "KY", PurchasePrice = 7000, PurchaseType = "Dealer Finance", UserId = "000000-0000-0000-0000-000000", ZipCode = 12345},
                new Sales {SalesId = 4, VehicleId = 4, BuyerName = "Carol Hart", Email ="carolhart@gmail.com", Phone = "859-333-2334", Street1 = "222 Lane Avenue", Street2 = "345 Street Drive", DatePurchased = new DateTime(2015, 02, 01), City = "Louisville", StateName = "KY", PurchasePrice = 8000, PurchaseType = "Cash", UserId = "000000-0000-0000-0000-000000", ZipCode = 67856}
            };
        }

        public IEnumerable<SalesReportRequest> GetSales()
        {
            List<SalesReportRequest> salesReportList = new List<SalesReportRequest>();

            foreach (var user in _users)
            {       
                SalesReportRequest salesReport = new SalesReportRequest();
                salesReport.UserName = user.FirstName + " " + user.LastName;
                salesReport.FirstName = user.FirstName;
                salesReport.LastName = user.LastName;

                foreach(var sale in _sales)
                {
                    if(sale.UserId == user.UserId)
                    {
                        salesReport.TotalSales = salesReport.TotalSales + sale.PurchasePrice;
                        salesReport.TotalVehicles = salesReport.TotalVehicles + 1;
                    }
                }
                if(salesReport.TotalSales != 0)
                {
                    salesReportList.Add(salesReport);
                }  
            }

            return salesReportList;
        }

        public void InsertSale(Sales sale)
        {
            _sales.Add(sale);
        }

        public IEnumerable<SalesReportRequest> GetSalesSearchResults(SalesSearchParameters parameters)
        {

            List<Sales> results = _sales;
            var sales = _sales;
            var users = _users;

            if (parameters.FromDate != null && parameters.ToDate != null)
            {
                DateTime fromDate = Convert.ToDateTime(parameters.FromDate);
                DateTime toDate = Convert.ToDateTime(parameters.ToDate);
                sales = (from sale in sales
                         where sale.DatePurchased <= toDate && sale.DatePurchased >= fromDate
                         select sale).ToList();

            }

            if (parameters.FromDate == null && parameters.ToDate != null)
            {
                DateTime fromDate = Convert.ToDateTime(parameters.FromDate);
                DateTime toDate = Convert.ToDateTime(parameters.ToDate);
                sales = (from sale in sales
                         where sale.DatePurchased <= toDate
                         select sale).ToList();
            }

            if (parameters.FromDate != null && parameters.ToDate == null)
            {
                DateTime fromDate = Convert.ToDateTime(parameters.FromDate);
                DateTime toDate = Convert.ToDateTime(parameters.ToDate);
                sales = (from sale in sales
                         where sale.DatePurchased >= fromDate
                         select sale).ToList();
            }


            if (parameters.UserName != null)
            {
                sales = (from user in _users
                         join sale in sales on user.UserId equals sale.UserId
                         where user.FirstName.Contains(parameters.UserName) || user.LastName.Contains(parameters.UserName)
                         select sale).ToList();
            }

            var salesReportRequest = new List<SalesReportRequest>();


            salesReportRequest = (from user in users
                                  join sale in sales on user.UserId equals sale.UserId
                                  select new SalesReportRequest()
                                  {
                                      DatePurchased = sale.DatePurchased,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      UserId = user.UserId,
                                      UserName = user.FirstName + " " + user.LastName
                                  }).ToList();


            var report = salesReportRequest.GroupBy(s => s.UserId).Select(s => s);
            var selectedReport = (from r in report
                                 select new SalesReportRequest()
                                 {
                                     FirstName = users.Find(u => u.UserId == r.Key).FirstName,
                                     LastName = users.Find(u => u.UserId == r.Key).LastName,
                                     TotalSales = sales.Where(s => s.UserId == r.Key).Sum(s => s.PurchasePrice),
                                     TotalVehicles = sales.Where(s => s.UserId == r.Key).Count(),

                                 }).ToList();

            foreach(var item in selectedReport)
            {
                item.UserName = item.FirstName + " " + item.LastName;
            }

            return selectedReport;
        }

        public IEnumerable<Sales> GetAllSales()
        {
            return _sales;
        }
    }
}
