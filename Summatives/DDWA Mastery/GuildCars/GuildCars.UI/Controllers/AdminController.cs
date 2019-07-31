using GuildCar.Data.Factory;
using GuildCars.Model;
using GuildCars.Model.Queries;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace GuildCars.UI.Controllers
{
    public class AdminController : Controller
    {
        private string GetUserId()
        {
            var usrManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = usrManger.FindByName(User.Identity.Name);
            return user.Id;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Vehicles()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddVehicle()
        {
            var model = new VehicleViewModel();
            model = model.GetLists();
            model.vehicle = new Vehicle();
            model.UserId = GetUserId();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel viewModel)
        {
            var vehicleRepo = VehicleFactory.GetVehicleRepository();

            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.vehicle.UserId = GetUserId();

                    if (viewModel.ImageUpload != null && viewModel.ImageUpload.ContentLength > 0)
                    {

                        var savepath = Server.MapPath("~/Images");


                        string fileName = Path.GetFileNameWithoutExtension(viewModel.ImageUpload.FileName);
                        string extension = Path.GetExtension(viewModel.ImageUpload.FileName);
                        var filePath = Path.Combine(savepath, fileName + extension);

                            filePath = Path.Combine(savepath, "inventory-" + viewModel.vehicle.VehicleId + extension);
                               
                        WebImage img = new WebImage(viewModel.ImageUpload.InputStream);
                        img.Resize(150, 100, preserveAspectRatio: false, preventEnlarge: true).Crop(1, 1);
                        img.Save(filePath);

                        viewModel.vehicle.PictureFileName = Path.GetFileName(filePath);
                    }

                    vehicleRepo.InsertVehicle(viewModel.vehicle);
                    var param = new VehicleSearchParameters();
                    viewModel.vehicle.VehicleId = vehicleRepo.GetSearchResults(param).Count();
                }

                else
                {
                    viewModel = viewModel.GetLists();
                    viewModel.UserId = GetUserId();
                    viewModel.vehicle = new Vehicle();

                   return View(viewModel);             
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

            return RedirectToAction("EditVehicle", new { id = viewModel.vehicle.VehicleId });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleEditViewModel();

            model = model.GetLists();
            model.UserId = GetUserId();
            model.vehicle = VehicleFactory.GetVehicleRepository().GetVehicle(id);
            

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditVehicle(VehicleEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                var vehicleRepo = VehicleFactory.GetVehicleRepository();


                model.vehicle.UserId = GetUserId();

                    var oldVehicle = vehicleRepo.GetVehicleDetails(model.vehicle.VehicleId);

                if (model.ImageUpload != null && model.ImageUpload.ContentLength != 0)
                {
                    var savepath = Server.MapPath("~/Images");

                    string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);
                    var filePath = Path.Combine(savepath, fileName + extension);

                    while (System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(savepath, "inventory-" + model.vehicle.VehicleId + extension);
                    }

                    WebImage img = new WebImage(model.ImageUpload.InputStream);
                    img.Resize(150, 100, preserveAspectRatio: false, preventEnlarge: true).Crop(1, 1);
                    img.Save(filePath);

                    model.vehicle.PictureFileName = Path.GetFileName(filePath);

                    var oldPath = Path.Combine(savepath, oldVehicle.PictureFileName);

                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                else
                {
                    //Did not replace the old file, so keep it
                    model.vehicle.PictureFileName = oldVehicle.PictureFileName;
                }
                vehicleRepo.UpdateVehicle(model.vehicle);

                    return RedirectToAction("Vehicles");

            }
            else
            {
                var modelEdit = new VehicleEditViewModel();
                modelEdit.UserId = GetUserId();
                var repo = VehicleFactory.GetVehicleRepository();
                modelEdit = modelEdit.GetLists();
                modelEdit.vehicle = repo.GetVehicle(model.vehicle.VehicleId);

                return View(modelEdit);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RemoveVehicle(VehicleEditViewModel viewModel)
        {
            var repo = VehicleFactory.GetVehicleRepository();

                var vehicle = repo.GetVehicle(viewModel.vehicle.VehicleId);

                vehicle.IsDeleted = true;
                var savepath = Server.MapPath("~/Images/");
                string filePath = savepath + Path.GetFileName(vehicle.PictureFileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                repo.UpdateVehicle(vehicle);

                return RedirectToAction("Vehicles");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Makes()
        {
            var model = new MakesModelsViewModel();
            model.makes = VehicleFactory.GetVehicleRepository().GetAllMakes();

            foreach (var item in model.makes)
            {
                item.DateAdded = item.DateAdded.Date;
                item.DateAddedString = item.DateAdded.ToString("d");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Makes(Make make)
        {
            var repo = VehicleFactory.GetVehicleRepository();
            
            make.DateAdded = DateTime.Now;
            make.UserId = GetUserId();

            repo.InsertMake(make);

            var viewModel = new MakesModelsViewModel();
            viewModel.models = VehicleFactory.GetVehicleRepository().GetAllModels();
            viewModel.makes = VehicleFactory.GetVehicleRepository().GetAllMakes();

            foreach (var item in viewModel.makes)
            {
                item.DateAdded = item.DateAdded.Date;
                item.DateAddedString = item.DateAdded.ToString("d");
            }

            viewModel.makeList = new SelectList(VehicleFactory.GetVehicleRepository().GetAllMakes(), "MakeId", "MakeName");

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Models()
        {
            var viewModel = new MakesModelsViewModel();
            viewModel.models = VehicleFactory.GetVehicleRepository().GetAllModels();
            viewModel.makes = VehicleFactory.GetVehicleRepository().GetAllMakes();

            viewModel.makeList = new SelectList(VehicleFactory.GetVehicleRepository().GetAllMakes(), "MakeId", "MakeName");

            foreach(var item in viewModel.models)
            {
                item.DateAdded = item.DateAdded.Date;
                item.DateAddedString = item.DateAdded.ToString("d");
            }

            foreach (var item in viewModel.models)
            {
                item.MakeName = viewModel.makes.Where(c => c.MakeId == item.MakeId).First().MakeName;
            }


            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Models(Model.Model model)
        {
            var repo = VehicleFactory.GetVehicleRepository();
            model.DateAdded = DateTime.Now;
            model.UserId = GetUserId();

            repo.InsertModel(model);

            var viewModel = new MakesModelsViewModel();
            viewModel.models = VehicleFactory.GetVehicleRepository().GetAllModels();
            viewModel.makes = VehicleFactory.GetVehicleRepository().GetAllMakes();
            foreach (var item in viewModel.models)
            {
                item.DateAdded = item.DateAdded.Date;
                item.DateAddedString = item.DateAdded.ToString("d");
            }

            viewModel.makeList = new SelectList(VehicleFactory.GetVehicleRepository().GetAllMakes(), "MakeId", "MakeName");
            viewModel.makes = VehicleFactory.GetVehicleRepository().GetAllMakes();
            viewModel.models = VehicleFactory.GetVehicleRepository().GetAllModels();

            foreach (var item in viewModel.models)
            {
                foreach(var make in viewModel.makes)
                {
                    if(item.MakeId == make.MakeId)
                    {
                        item.MakeName = make.MakeName;
                    }
                }
            }
                               

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Specials()
        {
            var repo = SpecialFactory.GetSpecialRepository();
            var viewModel = new SpecialViewModel();
            
            viewModel.specials = repo.GetSpecials();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteSpecial(SpecialViewModel viewModel)
        {
            
            var repo = SpecialFactory.GetSpecialRepository();

            repo.DeleteSpecials(viewModel.newSpecial.SpecialId);


            viewModel.specials = repo.GetSpecials();

            return RedirectToAction("Specials", viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Specials(SpecialViewModel viewModel)
        {
            var repo = SpecialFactory.GetSpecialRepository();

            repo.InsertSpecial(viewModel.newSpecial);

            viewModel.specials = repo.GetSpecials();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            var model = UsersFactory.GetUsersRepository().GetAllUsers();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
            var context = new ApplicationDbContext();
            var viewModel = new UserViewModel();

            viewModel.User = new ApplicationUser();
            viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddUser(UserViewModel viewModel)
        {
            var context = new ApplicationDbContext();
            if (!ModelState.IsValid)
            {
                viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
                return View(viewModel);
            }

            try
            {
                var store = new UserStore<ApplicationUser>(context);
                var usrManager = new UserManager<ApplicationUser>(store);

                var user = viewModel.User;
                user.isEnabled = true;
                user.Email = user.UserName;

                var success = usrManager.Create(user, user.PasswordHash);
                if(success.Succeeded)
                {
                    success = usrManager.AddToRole(user.Id, user.roleId);
                }

                return RedirectToAction("Users");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize(Roles = "Admin")]
        public  ActionResult EditUser(string id)
        {
            UserViewModel viewModel = new UserViewModel();
            var context = new ApplicationDbContext();
            var store = new UserStore<ApplicationUser>(context);
            var usrManger = new UserManager<ApplicationUser>(store);

            viewModel.User = usrManger.FindById(id);
            viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
            viewModel.User.PasswordHash = "";

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditUser(UserViewModel viewModel)
        {

            var context = new ApplicationDbContext();
            if (!ModelState.IsValid)
            {
                viewModel.Roles = new SelectList(context.Roles.ToList(), "Name", "Name");
                return View(viewModel);
            }

            try
            {
                ApplicationUser appUser = new ApplicationUser();
                var store = new UserStore<ApplicationUser>(context);
                var usrManager = new UserManager<ApplicationUser>(store);

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var user = usrManager.FindById(viewModel.User.Id);
                var role = user.roleId;

                user.roleId = viewModel.User.roleId;
                user.PasswordHash = usrManager.PasswordHasher.HashPassword(viewModel.User.PasswordHash);
                user.Email = viewModel.User.UserName;
                user.UserName = viewModel.User.UserName;
                user.firstName = viewModel.User.firstName;
                user.lastName = viewModel.User.lastName;
                usrManager.RemoveFromRoles(viewModel.User.Id, role);

                if (user.roleId != "Disabled")
                {
                    user.isEnabled = true;
                }
                else
                {
                    user.isEnabled = false;
                }

                var success = usrManager.Update(user);

                if (success.Succeeded)
                {
                    success = usrManager.AddToRole(user.Id, user.roleId);
                }

                if (role == "Admin" && user.roleId != "Admin" && User.Identity.GetUserId() == user.Id)
                {
                    FormsAuthentication.SignOut();
                    Roles.DeleteCookie();
                    Session.Clear();
                }

                return RedirectToAction("Users");
            }
            catch(Exception ex)
            {
                throw ex;

            }
     
        }
    } 
}