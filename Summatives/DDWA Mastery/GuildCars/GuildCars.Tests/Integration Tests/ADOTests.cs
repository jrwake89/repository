using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCar.Data.ADO;
using GuildCar.Data.Factory;
using GuildCar.Data.Mock_Repository;
using GuildCars.Model;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using NUnit.Framework;

namespace GuildCars.Tests.Integration_Tests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();

            }

            MockSalesRepository repoSales = new MockSalesRepository();
            repoSales.ResetSalesRepository();

            MockSpecialRepository repoSpecial = new MockSpecialRepository();
            repoSpecial.ResetSpecials();

            MockVehicleRepository repoVehicle = new MockVehicleRepository();
            repoVehicle.ResetVehicles();
        }

        [Test]
        public void CanLoadSales()
        {
            var repo = SalesFactory.GetSalesRepository();

            var sales = repo.GetSales().ToList();

            Assert.AreEqual("Rad", sales[0].FirstName);
            Assert.AreEqual(4, sales[0].TotalVehicles);
            Assert.AreEqual(26500, sales[0].TotalSales);
        }

        [Test]
        public void CanInsertSales()
        {
            var repo = SalesFactory.GetSalesRepository();

            DateTime dateTime = DateTime.Now;

            var sale = new Sales()
            {
                Phone = "8595478005",
                VehicleId = 6,
                BuyerName = "Randy Smith",
                Email = "jrwake89@gmail.com",
                Street1 = "10854 War Drive",
                ZipCode = 13456,
                City = "Frankfort",
                StateName = "KY",
                PurchasePrice = 12000,
                DatePurchased = dateTime,
                PurchaseType = "Dealer Finance",
                UserId = "000000-0000-0000-0000-000000"
            };

            repo.InsertSale(sale);

            var sales = SalesFactory.GetSalesRepository().GetAllSales();


            Assert.AreEqual(sales.Count(), 5);
        }

        [Test]
        public void CanLoadFeatured()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var featuredList = repo.GetFeatured();

            Assert.AreEqual(8, featuredList.Count());

        }

        [Test]
        public void CanSearchOnMinPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { minPrice = 13000M});

            Assert.AreEqual(4, found.Count());

        }

        [Test]
        public void CanSearchOnMaxPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { maxPrice = 13000M });

            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void CanSearchMaxAndMinPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { minPrice = 11000M, maxPrice = 13000M });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnMaxYear()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { maxYear = 2010 });

            Assert.AreEqual(1, found.Count());

        }

        [Test]
        public void CanSearchOnMinYear()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { minYear = 2011 });

            Assert.AreEqual(7, found.Count());
        }

        [Test]
        public void CanSearchOnMaxAndMinYear()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { maxYear = 2014, minYear = 2009 });

            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void CanSearchOnMake()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford" });

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchOnModel()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Civic" });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnYear()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "2010" });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnYearAndMaxPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "2010", maxPrice = 12000 });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnYearAndMaxPriceAndMinPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "2014", maxPrice = 14500, minPrice = 12000 });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnYearAndMinPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "2015", minPrice = 13000 });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchVehicle()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { });

            Assert.AreEqual(8, found.Count());
        }

        [Test]
        public void CanSearchSalesName()
        {
            var repo = SalesFactory.GetSalesRepository();

            var found = repo.GetSalesSearchResults(new SalesSearchParameters {UserName = "Rad" }).ToList();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual("Rad", found[0].FirstName);
            Assert.AreEqual(26500, found[0].TotalSales);
            Assert.AreEqual(4, found[0].TotalVehicles);
        }

        [Test]
        public void CanSearchSalesToDate()
        {
            var repo = SalesFactory.GetSalesRepository();

            DateTime dateTime = new DateTime(2001, 01, 01);

            var parameters = new SalesSearchParameters { ToDate = DateTime.Parse("01/02/2016") };
            var found = repo.GetSalesSearchResults(parameters).ToList();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual("Rad", found[0].FirstName);
            Assert.AreEqual(14500, found[0].TotalSales);
            Assert.AreEqual(2, found[0].TotalVehicles);
        }

        [Test]
        public void CanSearchSalesFromDate()
        {
            var repo = SalesFactory.GetSalesRepository();

            var parameters = new SalesSearchParameters { FromDate = DateTime.Parse("01/02/2015") };
            var found = repo.GetSalesSearchResults(parameters).ToList();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual("Rad", found[0].FirstName);
            Assert.AreEqual(20000, found[0].TotalSales);
            Assert.AreEqual(3, found[0].TotalVehicles);
        }

        [Test]
        public void CanSearchSalesBetweenDates()
        {
            var repo = SalesFactory.GetSalesRepository();


            var parameters = new SalesSearchParameters { ToDate = DateTime.Parse("02/04/2016"), FromDate = DateTime.Parse("01/02/2009") };
            var found = repo.GetSalesSearchResults(parameters).ToList();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual("Joes", found[0].LastName);
            Assert.AreEqual(14500, found[0].TotalSales);
            Assert.AreEqual(2, found[0].TotalVehicles);
        }

        [Test]
        public void CanSearchSales()
        {
            var repo = SalesFactory.GetSalesRepository();

            var found = repo.GetSalesSearchResults(new SalesSearchParameters { }).ToList();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual("Rad", found[0].FirstName);
            Assert.AreEqual(26500, found[0].TotalSales);
            Assert.AreEqual(4, found[0].TotalVehicles);
        }

        [Test]
        public void CanSearchOnMakeAndMaxPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford", maxPrice = 11000 });

            Assert.AreEqual(2, found.Count());
        }


        [Test]
        public void CanSearchOnMakeAndMinPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford", minPrice = 9000 });

            Assert.AreEqual(3, found.Count());
        }


        [Test]
        public void CanSearchOnMakeAndMaxPriceandMinPrice()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford", maxPrice = 12000, minPrice = 10500 });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnMakeAndPricesandMinYear()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford", maxPrice = 12000, minPrice = 10500, minYear = 2010 });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnMakeAndPricesandMaxYear()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford", maxPrice = 12000, minPrice = 10500, maxYear = 2016 });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnMakeAndPricesandYears()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var found = repo.GetSearchResults(new VehicleSearchParameters { search = "Ford", maxPrice = 12000, minPrice = 10000, maxYear = 2016, minYear = 2010 });

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanGetSpecials()
        {
            var repo = SpecialFactory.GetSpecialRepository();

            var specialList = repo.GetSpecials();

            Assert.AreEqual(3, specialList.Count());

        }

        [Test]
        public void CanInsertSpecial()
        {
            var repo = SpecialFactory.GetSpecialRepository();

            var special = new Special()
            {
                SpecialDesc = "0% interest down this weekend only!",
                SpecialTitle = "Summer Savings!"
            };

            repo.InsertSpecial(special);

            var specialList = repo.GetSpecials().ToList();

            Assert.AreEqual(4, specialList.Count);
        }

        [Test]
        public void CanInsertMake()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            DateTime dateTime = new DateTime(2019, 01, 01);

            var make = new Make
            {
                MakeName = "Chevrolet",
                DateAdded = dateTime,
                UserId = "71a7365f-de86-485d-9b09-443e5ee71394"
            };

            repo.InsertMake(make);

            var makeLoaded = repo.GetMakeById(5);

            Assert.AreEqual("Chevrolet", makeLoaded.MakeName);
        }

        [Test]
        public void CanInsertModel()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            DateTime dateTime = new DateTime(2019, 01, 01);

            var model = new Model.Model
            {
                ModelName = "Explorer",
                MakeId = 1,
                DateAdded = dateTime,
                UserId = "71a7365f-de86-485d-9b09-443e5ee71394"
            };

            repo.InsertModel(model);

            var loadedModel = repo.GetModelById(8);

            Assert.AreEqual(8, loadedModel.ModelId);
            Assert.AreEqual("Explorer", loadedModel.ModelName);
        }

        [Test]
        public void CanLoadVehicleDetails()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var vehicle = repo.GetVehicleDetails(1);

            Assert.IsNotNull(vehicle);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual("Taurus", vehicle.ModelName);
            Assert.AreEqual("Ford", vehicle.MakeName);
            Assert.AreEqual("Blue", vehicle.ColorType);
            Assert.AreEqual("Automatic", vehicle.TransmitionType);
            Assert.AreEqual("Black", vehicle.InteriorType);
            Assert.AreEqual(20000, vehicle.Mileage);
            Assert.AreEqual("12345", vehicle.VinNum);
            Assert.AreEqual(2010, vehicle.Year);
            Assert.AreEqual("A Wonderful car with a few cosmetic issues", vehicle.Descrip);
            Assert.AreEqual(12000, vehicle.MSRP);
            Assert.AreEqual(10000, vehicle.SalesPrice);
            Assert.AreEqual("Car", vehicle.BodyStyle);
            Assert.AreEqual("inventory-1.jpg", vehicle.PictureFileName);
            Assert.AreEqual(false, vehicle.IsNew);
            Assert.AreEqual(false, vehicle.IsDeleted);
        }

        [Test]
        public void CanLoadVehicleDetailsReturnsNull()
        {
            var repo = VehicleFactory.GetVehicleRepository();

            var vehicle = repo.GetVehicleDetails(100000);

            Assert.IsNull(vehicle);
        }



        [Test]
        public void CanInsertVehicle()
        {

            var repo = VehicleFactory.GetVehicleRepository();

            var vehicle = new Vehicle
            {
                MakeId = 2,
                ModelId = 3,
		        ColorId = 3,
		        TransmitionId = 2,
		        InteriorId = 2,
		        Mileage = 50000,
		        VinNum = "56789",
                Year = 2014,
		        Descrip = "One of the best prices on the lot!",
		        MSRP = 15000,
		        SalesPrice = 13000,
		        BodyStyleId = 2,
		        PictureFileName = "inventory-4.jpg",
		        IsSold = false,
		        IsFeatured = false,
		        IsNew = false
            };

            repo.InsertVehicle(vehicle);

            Assert.AreEqual(9, vehicle.VehicleId);
        }

        [Test]
        public void CanUpdateVehicle()
        {

            var repo = VehicleFactory.GetVehicleRepository();

            var vehicle = new Vehicle
            {
                MakeId = 2,
                ModelId = 3,
                ColorId = 3,
                TransmitionId = 2,
                InteriorId = 2,
                Mileage = 50000,
                VinNum = "56789",
                Year = 2014,
                Descrip = "One of the best prices on the lot!",
                MSRP = 16000,
                SalesPrice = 13000,
                BodyStyleId = 2,
                PictureFileName = "inventory-4.jpg",
                IsSold = false,
                IsFeatured = false,
                IsNew = false
            };

            repo.InsertVehicle(vehicle);


            vehicle.MSRP = 15000;
            vehicle.MakeId = 3;
            vehicle.ModelId = 3;
            vehicle.ColorId = 2;
            vehicle.TransmitionId = 1;
            vehicle.InteriorId = 1;
            vehicle.Mileage = 55000;
            vehicle.VinNum = "12345";
            vehicle.BodyStyleId = 1;
            vehicle.PictureFileName = "inventory-5.jpg";
            vehicle.IsFeatured = true;
            vehicle.IsNew = true;
            vehicle.SalesPrice = 13000;
            vehicle.IsSold = true;

            repo.UpdateVehicle(vehicle);

            var updatedListing = repo.GetVehicleDetails(9);
            Assert.AreEqual(15000, updatedListing.MSRP);
            Assert.AreEqual(55000, updatedListing.Mileage);
            Assert.AreEqual(13000, updatedListing.SalesPrice);
            Assert.AreEqual(true, updatedListing.IsSold);
            Assert.AreEqual("Toyota", updatedListing.MakeName);
            Assert.AreEqual("Camry", updatedListing.ModelName);
            Assert.AreEqual("Car", updatedListing.BodyStyle);
            Assert.AreEqual("12345", updatedListing.VinNum);
            Assert.AreEqual("inventory-5.jpg", updatedListing.PictureFileName);
            Assert.AreEqual(true, updatedListing.IsNew);
            Assert.AreEqual(true, updatedListing.IsFeatured);
            Assert.AreEqual("Automatic", updatedListing.TransmitionType);
            Assert.AreEqual("Black", updatedListing.InteriorType);
        }

        [Test]

        public void CanDeleteVehicle()
        {
            var repoVehicle = VehicleFactory.GetVehicleRepository();

            var param = new VehicleSearchParameters();

            var vehicle = new Vehicle
            {
                MakeId = 2,
                ModelId = 3,
                ColorId = 3,
                TransmitionId = 2,
                InteriorId = 2,
                Mileage = 50000,
                VinNum = "56789",
                Year = 2014,
                Descrip = "One of the best prices on the lot!",
                MSRP = 15000,
                SalesPrice = 13000,
                BodyStyleId = 2,
                PictureFileName = "inventory-4.jpg",
                IsSold = false,
                IsFeatured = false,
                IsNew = false
            };

            repoVehicle.InsertVehicle(vehicle);


            var loadedVehicle = repoVehicle.GetVehicle(4);
            loadedVehicle.IsDeleted = true;
            repoVehicle.UpdateVehicle(loadedVehicle);

            var found = repoVehicle.GetSearchResults(param);

            found = found.Where(x => x.IsDeleted == false);
            
            Assert.AreEqual(8, found.Count());
        }

        [Test]

        public void CanDeleteSpecial()
        {
            Init();
            var repo = SpecialFactory.GetSpecialRepository();

            var special = new Special()
            {
                SpecialDesc = "0% interest down this weekend only!",
                SpecialTitle = "Summer Savings!"
            };

            repo.InsertSpecial(special);

            var specialsList = repo.GetSpecials().ToList();
            Assert.IsNotNull(specialsList[3]);

            repo.DeleteSpecials(4);
            specialsList = repo.GetSpecials().ToList();

            Assert.AreEqual(3,specialsList.Count);
        }
    }


}
