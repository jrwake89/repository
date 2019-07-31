using GuildCar.Data.Factory;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class SalesController : Controller
    {
        [Authorize(Roles = "Sales")]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                var usrManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = usrManger.FindByName(User.Identity.Name);
                ViewBag.userId = user.Id;

                return View();
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [Authorize(Roles = "Sales")]
        public ActionResult Purchase(int id)
        {
            if (Request.IsAuthenticated)
            {
                var usrManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = usrManger.FindByName(User.Identity.Name);
                ViewBag.userId = user.Id;

                var viewModel = new PurchaseViewModel();

                viewModel.VehicleDetails = VehicleFactory.GetVehicleRepository().GetVehicleDetails(id);
                TempData["MileageDisplay"] = viewModel.VehicleDetails.Mileage.ToString("#,###");
                TempData["SalesPriceDisplay"] = viewModel.VehicleDetails.SalesPrice.ToString("#,###");
                TempData["MSRPDisplay"] = viewModel.VehicleDetails.MSRP.ToString("#,###");

                return View(viewModel);
            }

            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel viewModel)
        {
            viewModel.Sale.MSRP = viewModel.VehicleDetails.MSRP;
            viewModel.Sale.SalesPrice = viewModel.VehicleDetails.SalesPrice;

            if (ModelState.IsValid)
            {
                try
                {
                    var usrManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var user = usrManger.FindByName(User.Identity.Name);

                    var salesRepo = SalesFactory.GetSalesRepository();
                    var vehicleRepo = VehicleFactory.GetVehicleRepository();
                    var vehicle = vehicleRepo.GetVehicle(viewModel.VehicleDetails.VehicleId);
                    vehicle.IsSold = true;

                    viewModel.Sale.VehicleId = vehicle.VehicleId;
                    viewModel.Sale.DatePurchased = DateTime.Now;
                    viewModel.Sale.UserId = user.Id;
                    salesRepo.InsertSale(viewModel.Sale);
                    vehicleRepo.UpdateVehicle(vehicle);


                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var viewModelReturn = new PurchaseViewModel();

                viewModelReturn.VehicleDetails = VehicleFactory.GetVehicleRepository().GetVehicleDetails(viewModel.VehicleDetails.VehicleId);
                TempData["MileageDisplay"] = viewModel.VehicleDetails.Mileage.ToString("#,###");
                TempData["SalesPriceDisplay"] = viewModel.VehicleDetails.SalesPrice.ToString("#,###");
                TempData["MSRPDisplay"] = viewModel.VehicleDetails.MSRP.ToString("#,###");

                return View(viewModelReturn);
            }

        }

        
    }
}