using Dapper;
using GuildCar.Data.Interfaces;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.ADO
{
    public class SalesRepository : ISalesRepository
    {

        public IEnumerable<SalesReportRequest> GetSales()
        {
            List<SalesReportRequest> sales = new List<SalesReportRequest>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetSales");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportRequest currentRow = new SalesReportRequest();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];
                        currentRow.UserName = currentRow.FirstName + " " + currentRow.LastName;

                        sales.Add(currentRow);
                    }

                    return sales;
                }
            }
        }

        public IEnumerable<SalesReportRequest> GetSalesSearchResults(SalesSearchParameters parameters)
        {
            SalesSearchParameters parameter = new SalesSearchParameters();
            List<SalesReportRequest> resultsList = new List<SalesReportRequest>();

            parameter.UserName = parameters.UserName;
            parameter.ToDate = parameters.ToDate;
            parameter.FromDate = parameters.FromDate;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                string query = "SELECT FirstName, LastName, SUM(PurchasePrice) AS TotalSales, COUNT(UserId) AS TotalVehicles FROM Sales INNER JOIN AspNetUsers u ON u.Id = Sales.UserId ";

                if (!string.IsNullOrEmpty(parameter.UserName))
                {
                    query += "AND CONCAT(FirstName,' ',LastName) Like @UserName ";
                    cmd.Parameters.AddWithValue("@UserName", parameters.UserName + '%');
                }

                if (parameter.ToDate.HasValue)
                {
                    query += "AND DatePurchased <= @ToDate ";
                    cmd.Parameters.AddWithValue("@ToDate", parameters.ToDate);
                }

                if (parameter.FromDate.HasValue)
                {
                    query += "AND DatePurchased >= @FromDate ";
                    cmd.Parameters.AddWithValue("@FromDate", parameters.FromDate);
                }

                query += "GROUP BY FirstName, LastName ORDER BY TotalSales, TotalVehicles";

                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SalesReportRequest currentRow = new SalesReportRequest();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];
                        currentRow.UserName = currentRow.FirstName + " " + currentRow.LastName;
                        

                        resultsList.Add(currentRow);
                    }

                    return resultsList;
                }
            }
        }

        public void InsertSale(Sales sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertSales", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                var param = new DynamicParameters();
                param.Add("@SalesId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                param.Add("@VehicleId", sale.VehicleId);
                param.Add("@Phone", sale.Phone);
                param.Add("@BuyerName", sale.BuyerName);
                param.Add("@Street1", sale.Street1);
                param.Add("@Street2", sale.Street2);
                param.Add("@Email", sale.Email);
                param.Add("@City", sale.City);
                param.Add("@ZipCode", sale.ZipCode);
                param.Add("@StateName", sale.StateName);
                param.Add("@PurchasePrice", sale.PurchasePrice);
                param.Add("@DatePurchased", sale.DatePurchased);
                param.Add("@PurchaseType", sale.PurchaseType);
                param.Add("@UserId", sale.UserId);

                cn.Execute("InsertSales", param, commandType: CommandType.StoredProcedure);

                sale.SalesId = param.Get<int>("@SalesId");
            }
        }

        //Use for Tests//
        public IEnumerable<Sales> GetAllSales()
        {
            List<Sales> sales = new List<Sales>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllSales");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var sale = new Sales();
                        sale.SalesId = (int)dr["SalesId"];
                        sale.VehicleId = (int)dr["VehicleId"];
                        sale.ZipCode = (int)dr["ZipCode"];
                        sale.Street1 = dr["Street1"].ToString();
                        sale.StateName = dr["StateName"].ToString();

                        sales.Add(sale);
                    }

                    return sales;
                }
            }
        }
    }
}

