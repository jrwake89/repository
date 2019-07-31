using GuildCar.Data.Factory;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {         
            return View();
        }

        public ActionResult Details(int id)
        {
            var model = VehicleFactory.GetVehicleRepository().GetVehicleDetails(id);
            TempData["MileageDisplay"] = model.Mileage.ToString("#,###");
            TempData["SalesPriceDisplay"] = model.SalesPrice.ToString("#,###");
            TempData["MSRPDisplay"] = model.MSRP.ToString("#,###");


            return View(model);
        }
    }
}