using GuildCar.Data.Factory;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Sales()
        {

            var viewModel = new SalesReportsViewModel();

            viewModel.users = UsersFactory.GetUsersRepository().GetAllUsers();
            
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [Authorize]
        public ActionResult inventory()
        {
            var model = VehicleFactory.GetVehicleRepository().GetInventoryReport();
            var viewModel = new InventoryViewModel();
            viewModel.NewCars = model.Where(m => m.IsNew == true);
            viewModel.UsedCars = model.Where(m => m.IsNew == false);

            foreach(var vehicle in viewModel.NewCars)
            {
                vehicle.StockValueString = vehicle.StockValue.ToString("N2");
            }

            foreach(var vehicle in viewModel.UsedCars)
            {
                vehicle.StockValueString = vehicle.StockValue.ToString("N2");
            }

            return View(viewModel);
        }
    }
}