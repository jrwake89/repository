using GuildCar.Data.Interfaces;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Model;
using Dapper;
using GuildCars.Model.Tables;

namespace GuildCar.Data.ADO
{
    public class VehicleRepository : IVehicleRepository
    {
        public IEnumerable<FeaturedVehicleItem> GetFeatured()
        {
            List<FeaturedVehicleItem> featuredList = new List<FeaturedVehicleItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetFeatured");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicleItem currentRow = new FeaturedVehicleItem();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        currentRow.Year = (int)dr["Year"];
                        currentRow.SalesPrice = (decimal)dr["SalesPrice"];
                        currentRow.vehicleId = (int)dr["VehicleId"];
                        currentRow.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);

                        featuredList.Add(currentRow);
                    }

                    return featuredList;
                }
            }
        }

        public IEnumerable<VehicleDetailsRequest> GetSearchResults(VehicleSearchParameters parameters)
        {
            VehicleSearchParameters parameter = new VehicleSearchParameters();
            List<VehicleDetailsRequest> resultsList = new List<VehicleDetailsRequest>();

            if (parameters.maxPrice == null)
            {
                parameter.maxPrice = 0;
            }
            else
            {
                parameter.maxPrice = parameters.maxPrice;
            }

            if (parameters.minPrice == null)
            {
                parameter.minPrice = 0;
            }
            else
            {
                parameter.minPrice = parameters.minPrice;
            }

            if (parameters.minYear == null)
            {
                parameter.minYear = 0;
            }
            else
            {
                parameter.minYear = parameters.minYear;
            }

            if (parameters.maxYear == null)
            {
                parameter.maxYear = 0;
            }
            else
            {
                parameter.maxYear = parameters.maxYear;
            }
            parameter.search = parameters.search;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                string query = "SELECT TOP 20 BodyStyle, ColorType, InteriorType, MakeName, Mileage, MSRP, SalesPrice, TransmitionType, VehicleId, VinNum, [Year], ModelName, IsNew, IsSold, IsFeatured, PictureFileName, IsDeleted FROM Vehicle v  INNER JOIN BodyStyle b ON v.BodyStyleId = b.BodyStyleId INNER JOIN Color c ON v.ColorId = c.ColorId INNER JOIN Interior i ON v.InteriorId = i.InteriorId INNER JOIN Make ma ON v.MakeId = ma.MakeId INNER JOIN Transmition t ON v.TransmitionId = t.TransmitionId INNER JOIN Model mo ON mo.ModelId = v.ModelId WHERE 1 = 1 ";

                if(parameter.minPrice != 0 && parameter.minPrice != null)
                {
                    query += "AND SalesPrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.minPrice.Value);
                }

                if (parameter.maxPrice != 0 && parameter.maxPrice != null)
                {
                    query += "AND SalesPrice <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.maxPrice.Value);
                }

                if (parameter.minYear != 0 && parameter.minYear != null)
                {
                    query += "AND [Year] >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.minYear);
                }

                if (parameter.maxYear != 0 && parameter.maxYear != null)
                {
                    query += "AND [Year] <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.maxYear);
                }

                if (!string.IsNullOrEmpty(parameter.search))
                {
                    query += "AND MakeName Like @Search OR ModelName LIKE @Search OR [Year] LIKE @Search ";
                    cmd.Parameters.AddWithValue("@Search", parameters.search + '%');
                }

                query += "ORDER BY MSRP DESC";

                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleDetailsRequest currentRow = new VehicleDetailsRequest();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.ColorType = dr["ColorType"].ToString();
                        currentRow.InteriorType = dr["InteriorType"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Mileage = Convert.ToDecimal(dr["Mileage"]);
                        currentRow.MSRP = Convert.ToDecimal(dr["MSRP"]);
                        currentRow.SalesPrice = Convert.ToDecimal(dr["SalesPrice"]);
                        currentRow.TransmitionType = dr["TransmitionType"].ToString();
                        currentRow.PictureFileName = dr["PictureFileName"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.VinNum = dr["VinNum"].ToString();
                        currentRow.Year = Convert.ToInt32(dr["Year"]);
                        currentRow.IsNew = Convert.ToBoolean(dr["IsNew"]);
                        currentRow.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                        currentRow.IsSold = Convert.ToBoolean(dr["IsSold"]);
                        currentRow.IsFeatured = Convert.ToBoolean(dr["IsFeatured"]);

                        resultsList.Add(currentRow);
                    }

                    return resultsList;
                }
            }
        }

        public VehicleDetailsRequest GetVehicleDetails(int vehicleId)
        {
            VehicleDetailsRequest vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicleDetails");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleDetailsRequest();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.ColorType = dr["ColorType"].ToString();
                        vehicle.InteriorType = dr["InteriorType"].ToString();
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        vehicle.Descrip = dr["Descrip"].ToString();
                        vehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                        vehicle.TransmitionType = dr["TransmitionType"].ToString();
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.VinNum = dr["VinNum"].ToString();
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.IsNew = Convert.ToBoolean(dr["IsNew"]);
                        vehicle.IsFeatured = Convert.ToBoolean(dr["IsFeatured"]);
                        vehicle.IsSold = Convert.ToBoolean(dr["IsSold"]);
                        if (dr["PictureFileName"] != DBNull.Value)
                        vehicle.PictureFileName = dr["PictureFileName"].ToString();
                        vehicle.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                    }

                    return vehicle;
                }
            }
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetVehicle");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.ColorId = (int)dr["ColorId"];
                        vehicle.InteriorId = (int)dr["InteriorId"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.MSRP = Convert.ToInt32(dr["MSRP"]);
                        vehicle.Descrip = dr["Descrip"].ToString();
                        vehicle.SalesPrice = Convert.ToInt32(dr["SalesPrice"]);
                        vehicle.TransmitionId = (int)dr["TransmitionId"];
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.VinNum = dr["VinNum"].ToString();
                        vehicle.Year = Convert.ToInt32(dr["Year"]);
                        vehicle.IsNew = Convert.ToBoolean(dr["IsNew"]);
                        vehicle.IsFeatured = Convert.ToBoolean(dr["IsFeatured"]);
                        vehicle.IsSold = Convert.ToBoolean(dr["IsSold"]);
                        vehicle.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);
                        if (dr["PictureFileName"] != DBNull.Value)
                            vehicle.PictureFileName = dr["PictureFileName"].ToString();
                    }

                    return vehicle;
                }
            }
        }

        public IEnumerable<Model> GetAllModels ()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllModels");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    Model model = new Model();

                    while (dr.Read())
                    {
                        model = new Model();
                        model.ModelId = (int)dr["ModelId"];
                        model.MakeId = (int)dr["MakeId"];
                        model.ModelName = dr["ModelName"].ToString();
                        model.DateAdded = (DateTime)dr["DateAdded"];
                        model.UserId = dr["Id"].ToString();
                        model.UserName = dr["Email"].ToString();

                        models.Add(model);
                    }     
                }
                return models;
            }
        }

        public Model GetModelById(int modelId)
        {
            Model model = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetModelById");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ModelId", modelId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        model = new Model();
                        model.ModelId = (int)dr["ModelId"];
                        model.MakeId = (int)dr["MakeId"];
                        model.ModelName = dr["ModelName"].ToString();
                        model.DateAdded = (DateTime)dr["DateAdded"];
                        model.UserId = dr["UserId"].ToString();
                    }   

                    return model;
                }
            }
        }

        public IEnumerable<Make> GetAllMakes()
        {
            List<Make> makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllMakes");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make make = new Make();

                        make.MakeName = dr["MakeName"].ToString();
                        make.DateAdded = (DateTime)dr["DateAdded"];
                        make.UserId = dr["Id"].ToString();
                        make.UserName = dr["Email"].ToString();
                        make.MakeId = (int)dr["MakeId"];
                        makes.Add(make);
                    }
                }

                return makes.ToList();
            }
        }

        public IEnumerable<Color> GetAllColors()
        {
            List<Color> colors = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllColors");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        Color color = new Color();
                        color.ColorType = dr["ColorType"].ToString();
                        color.ColorId = (int)dr["ColorId"];

                        colors.Add(color);
                    }       
                }

                return colors.ToList();
            }
        }

        public IEnumerable<Interior> GetAllInteriors()
        {
            List<Interior> interiors = new List<Interior>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllInteriors");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        Interior interior = new Interior();
                        interior.InteriorType = dr["InteriorType"].ToString();
                        interior.InteriorId = (int)dr["InteriorId"];

                        interiors.Add(interior);
                    }   
                }

                return interiors.ToList();
            }
        }

        public Make GetMakeById(int makeId)
        {
            Make make = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetMakeById");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        make = new Make();

                        make.MakeId = (int)dr["MakeId"];
                        make.MakeName = dr["MakeName"].ToString();
                        make.DateAdded = (DateTime)dr["DateAdded"];
                        make.UserId = dr["UserId"].ToString();

                    }

                    return make;
                }
            }
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("UpdateVehicle", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@ColorId", vehicle.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", vehicle.InteriorId);
                cmd.Parameters.AddWithValue("@TransmitionId", vehicle.TransmitionId);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VinNum", vehicle.VinNum);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Descrip", vehicle.Descrip);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                if (string.IsNullOrEmpty(vehicle.PictureFileName))
                {
                    cmd.Parameters.AddWithValue("@PictureFileName", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PictureFileName", vehicle.PictureFileName);
                }
                cmd.Parameters.AddWithValue("@IsSold", vehicle.IsSold);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@IsDeleted", vehicle.IsDeleted);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void InsertVehicle(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertVehicle", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                var param = new DynamicParameters();
                param.Add("@VehicleId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                
                param.Add("@ColorId", vehicle.ColorId);
                param.Add("@MakeId", vehicle.MakeId);
                param.Add("@ModelId", vehicle.ModelId);
                param.Add("@TransmitionId", vehicle.TransmitionId);
                param.Add("@InteriorId", vehicle.InteriorId);
                param.Add("@Mileage", vehicle.Mileage);
                param.Add("@VinNum", vehicle.VinNum);
                if(string.IsNullOrEmpty(vehicle.PictureFileName))
                {
                    param.Add("@PictureFileName", DBNull.Value);
                }
                else
                {
                    param.Add("@PictureFileName", vehicle.PictureFileName);
                }
                
                param.Add("@Year", vehicle.Year);
                param.Add("@Descrip", vehicle.Descrip);
                param.Add("@MSRP", vehicle.MSRP);
                param.Add("@SalesPrice", vehicle.SalesPrice);
                param.Add("@BodyStyleId", vehicle.BodyStyleId);
                param.Add("@IsSold", vehicle.IsSold);
                param.Add("@IsFeatured", vehicle.IsFeatured);
                param.Add("@IsNew", vehicle.IsNew);
                param.Add("@IsDeleted", vehicle.IsDeleted);


                cn.Execute("InsertVehicle", param, commandType: CommandType.StoredProcedure);

                vehicle.VehicleId = param.Get<int>("@VehicleId");
            }
        }

        public void InsertMake(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertMake", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                var param = new DynamicParameters();
                param.Add("@MakeId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                param.Add("@MakeName", make.MakeName);
                param.Add("@DateAdded", make.DateAdded);
                param.Add("@UserId", make.UserId);

                cn.Execute("InsertMake", param, commandType: CommandType.StoredProcedure);

                make.MakeId = param.Get<int>("@MakeId");
            }
        }

        public void InsertModel(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertModel", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                var param = new DynamicParameters();
                param.Add("@ModelId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                param.Add("@MakeId", model.MakeId);
                param.Add("@ModelName", model.ModelName);
                param.Add("@DateAdded", model.DateAdded);
                param.Add("@UserId", model.UserId);

                cn.Execute("InsertModel", param, commandType: CommandType.StoredProcedure);

                model.ModelId = param.Get<int>("@ModelId");     
            }
        }

        public void InsertContact(ContactUs contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertContact", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                var param = new DynamicParameters();
                param.Add("@ContactId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                param.Add("@ContactName", contact.ContactName);
                param.Add("@Phone", contact.Phone);
                param.Add("@Email", contact.Email);
                param.Add("@ContactMessage", contact.ContactMessage);

                cn.Execute("InsertContact", param, commandType: CommandType.StoredProcedure);

                contact.ContactId = param.Get<int>("@ContactId");
            }
        }

        public IEnumerable<InventoryReportRequest> GetInventoryReport()
        {
            List<InventoryReportRequest> requestList = new List<InventoryReportRequest>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetInventoryReport");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportRequest currentRow = new InventoryReportRequest();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.StockValue = (decimal)dr["Stock Value"];
                        currentRow.Count = (int)dr["Count"];
                        currentRow.Year = Convert.ToInt32(dr["Year"]);
                        currentRow.IsNew = Convert.ToBoolean(dr["IsNew"]);

                        requestList.Add(currentRow);
                    }

                    return requestList;
                }
            }
        }

    }
}
