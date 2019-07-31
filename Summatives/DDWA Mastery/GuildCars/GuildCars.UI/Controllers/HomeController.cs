using GuildCar.Data.Factory;
using GuildCars.Model;
using GuildCars.Model.Queries;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            return View(viewModel);
        }

        public ActionResult Specials()
        {
            HomeViewModel specials = new HomeViewModel()
            {
                specials = SpecialFactory.GetSpecialRepository().GetSpecials()
            };

            var model = specials;
            return View(model);
        }

        public ActionResult ContactUs(string VinNum)
        {
            var viewModel = new ContactViewModel();
            viewModel.VinNum = VinNum;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ContactUs(ContactViewModel contact)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    ContactUs contactUs = new ContactUs();
                    contactUs.ContactId = contact.ContactId;
                    contactUs.ContactMessage = contact.ContactMessage;
                    contactUs.ContactName = contact.ContactName;
                    contactUs.Email = contact.Email;
                    contactUs.Phone = contact.Phone;
                    var repo = VehicleFactory.GetVehicleRepository();

                    repo.InsertContact(contactUs);
                    HomeViewModel viewModel = new HomeViewModel();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                var model = new ContactViewModel();
                model.VinNum = contact.VinNum;
                return View("ContactUs", model);
            }

        }
    }
}