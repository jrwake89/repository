using GuildCar.Data.Interfaces;
using GuildCars.Model;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Mock_Repository
{
    public class MockVehicleRepository : IVehicleRepository
    {
        private static List<ContactUs> _contacts = new List<ContactUs>
        {
                new ContactUs {ContactId = 1, ContactName = "Joshua Wakfield", Email = "josh@josh.com", Phone = "111-222-3333", ContactMessage = "I'd like a car" }
        };

        private static List<BodyStyles> _bodyStyles = new List<BodyStyles>
            {
                new BodyStyles {BodyStyleId = 1, BodyStyle = "Car" },
                new BodyStyles {BodyStyleId = 2, BodyStyle = "SUV" },
                new BodyStyles {BodyStyleId = 3, BodyStyle = "Truck" },
                new BodyStyles {BodyStyleId = 4, BodyStyle = "Van" },
            };

        private static List<Make> _makes = new List<Make>
        {
                new Make {MakeId = 1, MakeName = "Ford" },
                new Make {MakeId = 2, MakeName = "Honda" },
                new Make {MakeId = 3, MakeName = "Toyota" },
                new Make {MakeId = 4, MakeName = "KIA" }
        };

        private static List<Model> _models = new List<Model>
        {
                new Model {ModelId = 1, ModelName = "Taurus" , MakeId = 1},
                new Model {ModelId = 2, ModelName = "Civic", MakeId = 2 },
                new Model {ModelId = 3, ModelName = "Camry", MakeId = 3 },
                new Model {ModelId = 4, ModelName = "Sorento", MakeId = 4 },
                new Model {ModelId = 5, ModelName = "CR-V", MakeId = 2 },
                new Model {ModelId = 6, ModelName = "Ranger", MakeId = 1 },
                new Model {ModelId = 7, ModelName = "RAV4", MakeId = 3 }
        };

        private static List<Transmition> _transmitions = new List<Transmition>
        {
                new Transmition {TransmitionId = 1, TransmitionName = "Automatic" },
                new Transmition {TransmitionId = 2, TransmitionName = "Manual" },
        };

        private static List<Color> _colors = new List<Color>
        {
                new Color {ColorId = 1, ColorType = "Blue" },
                new Color {ColorId = 2, ColorType = "Green" },
                new Color {ColorId = 3, ColorType = "Silver" },
                new Color {ColorId = 4, ColorType = "Black" },
                new Color {ColorId = 5, ColorType = "Gold" },
                new Color {ColorId = 6, ColorType = "Red" },
                new Color {ColorId = 7, ColorType = "White" },
                new Color {ColorId = 8, ColorType = "Grey" }
        };

        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
                new Vehicle {MakeId = 1, ModelId = 1, ColorId = 1, TransmitionId = 1,
                            InteriorId = 1, Mileage = 20000, VinNum = "12345", Year = 2010,
                            Descrip = "A Wonderful car with a few cosmetic issues", MSRP = 12000,
                            SalesPrice = 10000, BodyStyleId = 1, PictureFileName = "inventory-1.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, VehicleId = 1 },

                new Vehicle {MakeId = 1, ModelId = 1, ColorId = 2, TransmitionId = 2,
                            InteriorId = 1, Mileage = 75000, VinNum = "23456", Year = 2016,
                            Descrip = "Best deal on the lot", MSRP = 15000,
                            SalesPrice = 12000, BodyStyleId = 1, PictureFileName = "inventory-2.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, VehicleId = 2 },
                new Vehicle {MakeId = 2, ModelId = 2, ColorId = 3, TransmitionId = 2,
                            InteriorId = 1, Mileage = 50000, VinNum = "3456", Year = 2015,
                            Descrip = "Been in one accident but there was no major damage. Great car!", MSRP = 16000,
                            SalesPrice = 14000, BodyStyleId = 1, PictureFileName = "inventory-3.jpg",
                            IsSold = true, IsFeatured = true, IsNew = false, VehicleId = 3 },

                new Vehicle {MakeId = 3, ModelId = 3, ColorId = 1, TransmitionId = 1,
                            InteriorId = 4, Mileage = 500, VinNum = "1234", Year = 2019,
                            Descrip = "Brand new car. Top of the line!", MSRP = 21000,
                            SalesPrice = 19000, BodyStyleId = 1, PictureFileName = "inventory-4.jpg",
                            IsSold = false, IsFeatured = true, IsNew = true, IsDeleted = false, VehicleId = 4 },

                new Vehicle {MakeId = 4, ModelId = 4, ColorId = 7, TransmitionId = 1,
                            InteriorId = 3, Mileage = 76000, VinNum = "2345", Year = 2012,
                            Descrip = "Great car", MSRP = 10000,
                            SalesPrice = 9000, BodyStyleId = 2, PictureFileName = "inventory-5.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 5 },

                new Vehicle {MakeId = 2, ModelId = 5, ColorId = 1, TransmitionId = 2,
                            InteriorId = 1, Mileage = 54000, VinNum = "3456", Year = 2014,
                            Descrip = "Excellent car. Highest safety rating possible", MSRP = 16000,
                            SalesPrice = 14000, BodyStyleId = 2, PictureFileName = "inventory-6.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 6 },

                new Vehicle {MakeId = 1, ModelId = 6, ColorId = 8, TransmitionId = 1,
                            InteriorId = 3, Mileage = 120000, VinNum = "4567", Year = 2011,
                            Descrip = "Older truck that runs well", MSRP = 10000,
                            SalesPrice = 9000, BodyStyleId = 3, PictureFileName = "inventory-7.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 7 },

                new Vehicle {MakeId = 3, ModelId = 7, ColorId = 8, TransmitionId = 1,
                            InteriorId = 3, Mileage = 87000, VinNum = "5678", Year = 2016,
                            Descrip = "Great car with everything you need", MSRP = 16000,
                            SalesPrice = 14500, BodyStyleId = 2, PictureFileName = "inventory-.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 8 }
        };

        private static List<Interior> _interiors = new List<Interior>
        {
                new Interior {InteriorId = 1, InteriorType = "Black" },
                new Interior {InteriorId = 2, InteriorType = "Tan" },
                new Interior {InteriorId = 3, InteriorType = "Grey" },
                new Interior {InteriorId = 4, InteriorType = "White" }
        };

        public void ResetVehicles()
        {
            _vehicles = new List<Vehicle>
            {
                                new Vehicle {MakeId = 1, ModelId = 1, ColorId = 1, TransmitionId = 1,
                            InteriorId = 1, Mileage = 20000, VinNum = "12345", Year = 2010,
                            Descrip = "A Wonderful car with a few cosmetic issues", MSRP = 12000,
                            SalesPrice = 10000, BodyStyleId = 1, PictureFileName = "inventory-1.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, VehicleId = 1 },

                new Vehicle {MakeId = 1, ModelId = 1, ColorId = 2, TransmitionId = 2,
                            InteriorId = 1, Mileage = 75000, VinNum = "23456", Year = 2016,
                            Descrip = "Best deal on the lot", MSRP = 15000,
                            SalesPrice = 12000, BodyStyleId = 1, PictureFileName = "inventory-2.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, VehicleId = 2 },
                new Vehicle {MakeId = 2, ModelId = 2, ColorId = 3, TransmitionId = 2,
                            InteriorId = 1, Mileage = 50000, VinNum = "3456", Year = 2015,
                            Descrip = "Been in one accident but there was no major damage. Great car!", MSRP = 16000,
                            SalesPrice = 14000, BodyStyleId = 1, PictureFileName = "inventory-3.jpg",
                            IsSold = true, IsFeatured = true, IsNew = false, VehicleId = 3 },

                new Vehicle {MakeId = 3, ModelId = 3, ColorId = 1, TransmitionId = 1,
                            InteriorId = 4, Mileage = 500, VinNum = "1234", Year = 2019,
                            Descrip = "Brand new car. Top of the line!", MSRP = 21000,
                            SalesPrice = 19000, BodyStyleId = 1, PictureFileName = "inventory-4.jpg",
                            IsSold = false, IsFeatured = true, IsNew = true, IsDeleted = false, VehicleId = 4 },

                new Vehicle {MakeId = 4, ModelId = 4, ColorId = 7, TransmitionId = 1,
                            InteriorId = 3, Mileage = 76000, VinNum = "2345", Year = 2012,
                            Descrip = "Great car", MSRP = 10000,
                            SalesPrice = 9000, BodyStyleId = 2, PictureFileName = "inventory-5.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 5 },

                new Vehicle {MakeId = 2, ModelId = 5, ColorId = 1, TransmitionId = 2,
                            InteriorId = 1, Mileage = 54000, VinNum = "3456", Year = 2014,
                            Descrip = "Excellent car. Highest safety rating possible", MSRP = 16000,
                            SalesPrice = 14000, BodyStyleId = 2, PictureFileName = "inventory-6.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 6 },

                new Vehicle {MakeId = 1, ModelId = 6, ColorId = 8, TransmitionId = 1,
                            InteriorId = 3, Mileage = 120000, VinNum = "4567", Year = 2011,
                            Descrip = "Older truck that runs well", MSRP = 10000,
                            SalesPrice = 9000, BodyStyleId = 3, PictureFileName = "inventory-7.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 7 },

                new Vehicle {MakeId = 3, ModelId = 7, ColorId = 8, TransmitionId = 1,
                            InteriorId = 3, Mileage = 87000, VinNum = "5678", Year = 2016,
                            Descrip = "Great car with everything you need", MSRP = 16000,
                            SalesPrice = 14500, BodyStyleId = 2, PictureFileName = "inventory-.jpg",
                            IsSold = false, IsFeatured = true, IsNew = false, IsDeleted = false, VehicleId = 8 }
            };

            _bodyStyles = new List<BodyStyles>
            {
                new BodyStyles {BodyStyleId = 1, BodyStyle = "Car" },
                new BodyStyles {BodyStyleId = 2, BodyStyle = "SUV" },
                new BodyStyles {BodyStyleId = 3, BodyStyle = "Truck" },
                new BodyStyles {BodyStyleId = 4, BodyStyle = "Van" },
            };

            _models = new List<Model>
            {
                new Model {ModelId = 1, ModelName = "Taurus" , MakeId = 1},
                new Model {ModelId = 2, ModelName = "Civic", MakeId = 2 },
                new Model {ModelId = 3, ModelName = "Camry", MakeId = 3 },
                new Model {ModelId = 4, ModelName = "Sorento", MakeId = 4 },
                new Model {ModelId = 5, ModelName = "CR-V", MakeId = 2 },
                new Model {ModelId = 6, ModelName = "Ranger", MakeId = 1 },
                new Model {ModelId = 7, ModelName = "RAV4", MakeId = 3 }
            };

            _makes = new List<Make>
            {
                new Make {MakeId = 1, MakeName = "Ford" },
                new Make {MakeId = 2, MakeName = "Honda" },
                new Make {MakeId = 3, MakeName = "Toyota" },
                new Make {MakeId = 4, MakeName = "KIA" }
            };
        }

        public List<VehicleDetailsRequest> GetNamesFromId(List<Vehicle> vehicleList)
        {

            var vehicleDetailsList = (from vehicle in vehicleList
                               join model in _models on vehicle.ModelId equals model.ModelId
                               join make in _makes on vehicle.MakeId equals make.MakeId
                               join color in _colors on vehicle.ColorId equals color.ColorId
                               join bodyStyle in  _bodyStyles on vehicle.BodyStyleId equals bodyStyle.BodyStyleId
                               join transmition in _transmitions on vehicle.TransmitionId equals transmition.TransmitionId
                               join interior in _interiors on vehicle.InteriorId equals interior.InteriorId
                                     select new VehicleDetailsRequest { VehicleId = vehicle.VehicleId, ModelName = model.ModelName,
                                     MakeName = make.MakeName, ColorType = color.ColorType, MSRP = vehicle.MSRP, SalesPrice = vehicle.SalesPrice,
                                     BodyStyle = bodyStyle.BodyStyle, Descrip = vehicle.Descrip, IsFeatured = vehicle.IsFeatured, VinNum = vehicle.VinNum,
                                     IsNew = vehicle.IsNew, InteriorType = interior.InteriorType, IsSold = vehicle.IsSold, Mileage = vehicle.Mileage,
                                     PictureFileName = vehicle.PictureFileName, TransmitionType = transmition.TransmitionName, Year = vehicle.Year, IsDeleted = vehicle.IsDeleted});

            return vehicleDetailsList.ToList();
        }

        public IEnumerable<FeaturedVehicleItem> GetFeatured()
        {
            var featuredList = _vehicles.Where(v => v.IsFeatured == true).ToList();
            var featuredVehicleDetails = GetNamesFromId(featuredList);

            List<FeaturedVehicleItem> featuredVehicleItems = new List<FeaturedVehicleItem>();

            foreach(var vehicle in featuredVehicleDetails)
            {
                FeaturedVehicleItem featuredItem = new FeaturedVehicleItem
                {
                    MakeName = vehicle.MakeName,
                    vehicleId = vehicle.VehicleId,
                    ModelName = vehicle.ModelName,
                    Year = vehicle.Year,
                    PictureFileName = vehicle.PictureFileName,
                    SalesPrice = vehicle.SalesPrice
                };

                featuredVehicleItems.Add(featuredItem);
            }

            return featuredVehicleItems;
        }

        public IEnumerable<InventoryReportRequest> GetInventoryReport()
        {
            var vehicleDetails = GetNamesFromId(_vehicles);

            var vehicleGroups = from v in vehicleDetails
                               orderby v.Year
                               group v by v.ModelName;

            List<InventoryReportRequest> inventoryReportRequests = new List<InventoryReportRequest>();

            foreach (var vehicleGroup in vehicleGroups)
            {
                foreach(var vehicle in vehicleGroup)
                {

                    InventoryReportRequest request = new InventoryReportRequest();

                    request.MakeName = vehicle.MakeName;
                    request.ModelName = vehicle.ModelName;
                    request.Year = vehicle.Year;
                    request.Count = vehicleGroup.Where(v => v.ModelName == v.ModelName).Count();
                    request.StockValue = (request.Count) * vehicle.SalesPrice;
                    request.IsNew = vehicle.IsNew;
                    

                    inventoryReportRequests.Add(request);

                }
                
            }

            return inventoryReportRequests;
        }

        public Make GetMakeById(int makeId)
        {
            List<Make> makes = _makes.Where(m => m.MakeId == makeId).ToList();

            return makes[0];
        }

        public Model GetModelById(int modelId)
        {
            List<Model> models = _models.Where(m => m.ModelId == modelId).ToList();

            return models[0];
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            var vehicle = _vehicles.Where(v => v.VehicleId == vehicleId).ToList();

            return vehicle[0];
        }

        public VehicleDetailsRequest GetVehicleDetails(int vehicleId)
        {
            var vehicle = _vehicles.Where(v => v.VehicleId == vehicleId).ToList();
            var vehicleDetails = GetNamesFromId(vehicle).ToList();

            VehicleDetailsRequest finalVehicle = null;
            if(vehicleDetails.Count > 0)
            {
                foreach (var v in vehicleDetails)
                {
                    finalVehicle = new VehicleDetailsRequest();
                    finalVehicle.MakeName = v.MakeName;
                    finalVehicle.ModelName = v.ModelName;
                    finalVehicle.Year = v.Year;
                    finalVehicle.PictureFileName = v.PictureFileName;
                    finalVehicle.SalesPrice = v.SalesPrice;
                    finalVehicle.BodyStyle = v.BodyStyle;
                    finalVehicle.ColorType = v.ColorType;
                    finalVehicle.Descrip = v.Descrip;
                    finalVehicle.InteriorType = v.InteriorType;
                    finalVehicle.IsFeatured = v.IsFeatured;
                    finalVehicle.IsNew = v.IsNew;
                    finalVehicle.IsSold = v.IsSold;
                    finalVehicle.Mileage = v.Mileage;
                    finalVehicle.MSRP = v.MSRP;
                    finalVehicle.TransmitionType = v.TransmitionType;
                    finalVehicle.VehicleId = v.VehicleId;
                    finalVehicle.VinNum = v.VinNum;
                }
            }
            

            return finalVehicle;
        }

        public void InsertContact(ContactUs contact)
        {
            contact.ContactId = _contacts.Count() + 1;
            _contacts.Add(contact);

        }

        public void InsertMake(Make make)
        {
            make.MakeId = _makes.Count() + 1;
            _makes.Add(make);
        }

        public IEnumerable<Make> GetAllMakes()
        {
            return _makes;
        }

        public IEnumerable<Model> GetAllModels()
        {
            return _models;
        }

        public IEnumerable<Color> GetAllColors()
        {
            return _colors;
        }

        public IEnumerable<Interior> GetAllInteriors()
        {
            return _interiors;
        }

        public void InsertModel(Model model)
        {
            model.ModelId = _models.Count() + 1;
            _models.Add(model);
        }

        public void InsertVehicle(Vehicle vehicle)
        {
            vehicle.VehicleId = _vehicles.Count() + 1;
            _vehicles.Add(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _vehicles[(vehicle.VehicleId-1)] = vehicle;
        }

        public IEnumerable<VehicleDetailsRequest> GetSearchResults(VehicleSearchParameters parameters)
        {
            
            List<Vehicle> results = _vehicles;

            if (parameters.maxPrice.HasValue)
            {
                results = (from vehicle in results
                          where vehicle.SalesPrice <= parameters.maxPrice
                          select vehicle).ToList();

            }

            if (parameters.minPrice.HasValue)
            {
                results = (from vehicle in results
                          where vehicle.SalesPrice >= parameters.minPrice
                          select vehicle).ToList();
            }

            if (parameters.minYear != null)
            {
                results = (from vehicle in results
                          where vehicle.Year >= parameters.minYear
                          select vehicle).ToList();

            }

            if (parameters.maxYear != null)
            {
                results = (from vehicle in results
                          where vehicle.Year <= parameters.maxYear
                          select vehicle).ToList();
            }

            List<VehicleDetailsRequest> vehicleDetails = GetNamesFromId(results);

            bool successfullyParsed = int.TryParse(parameters.search, out int year);

            if (successfullyParsed == true)
            {
                vehicleDetails = (from vehicle in vehicleDetails
                                  where vehicle.Year == year
                                  select vehicle).ToList();

            }
            else
            {
                if (parameters.search != null)
                {
                    vehicleDetails = (from vehicle in vehicleDetails
                                      where vehicle.MakeName.Contains(parameters.search) || vehicle.ModelName.Contains(parameters.search)
                                      select vehicle).ToList();
                }

            }


            return vehicleDetails;
        }
    }
}
