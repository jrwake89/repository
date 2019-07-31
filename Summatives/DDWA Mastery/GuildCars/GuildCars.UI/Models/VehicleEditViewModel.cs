using GuildCar.Data.Factory;
using GuildCars.Model;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class VehicleEditViewModel:IValidatableObject
    {
        List<BodyStyles> bodyStyles = new List<BodyStyles>()
            {
                new BodyStyles { BodyStyleId = 1, BodyStyle = "Car"},
                new BodyStyles { BodyStyleId = 2, BodyStyle = "SUV"},
                new BodyStyles { BodyStyleId = 3, BodyStyle = "Truck"},
                new BodyStyles { BodyStyleId = 4, BodyStyle = "Van" }
            };

        List<Transmition> transmition = new List<Transmition>()
        {
            new Transmition {TransmitionId = 1, TransmitionName = "Automatic"},
            new Transmition {TransmitionId = 2, TransmitionName = "Maunal"}
        };

        List<CarType> usedOrNew = new List<CarType>()
        {
            new CarType { CarTypeId = true, CarTypeName = "New"},
            new CarType { CarTypeId = false, CarTypeName = "Used"}
        };


        public VehicleEditViewModel()
        {
            Makes = new SelectList(VehicleFactory.GetVehicleRepository().GetAllMakes(), "MakeId", "MakeName");
            Models = new SelectList(VehicleFactory.GetVehicleRepository().GetAllModels(), "ModelId", "ModelName");
            Colors = new SelectList(VehicleFactory.GetVehicleRepository().GetAllColors(), "ColorId", "ColorType");
            Interiors = new SelectList(VehicleFactory.GetVehicleRepository().GetAllInteriors(), "InteriorId", "InteriorType");
            BodyStyle = new SelectList(bodyStyles, "BodyStyleId", "BodyStyle");
            Transmition = new SelectList(transmition, "TransmitionId", "TransmitionName");
            CarType = new SelectList(usedOrNew, "CarTypeId", "CarTypeName");
        }
     
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Interiors { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Transmition { get; set; }
        public IEnumerable<SelectListItem> CarType { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public string UserId { get; set; }
        public Vehicle vehicle { get; set; }



        public VehicleEditViewModel GetLists()
        {
            VehicleEditViewModel viewModel = new VehicleEditViewModel();

            Makes = new SelectList(VehicleFactory.GetVehicleRepository().GetAllMakes(), "MakeId", "MakeName");
            Models = new SelectList(VehicleFactory.GetVehicleRepository().GetAllModels(), "ModelId", "ModelName");
            Colors = new SelectList(VehicleFactory.GetVehicleRepository().GetAllColors(), "ColorId", "ColorType");
            Interiors = new SelectList(VehicleFactory.GetVehicleRepository().GetAllInteriors(), "InteriorId", "InteriorType");
            BodyStyle = new SelectList(bodyStyles, "BodyStyleId", "BodyStyle");
            Transmition = new SelectList(transmition, "TransmitionId", "TransmitionName");


            return viewModel;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(vehicle.Year == 0 )
            {
                errors.Add(new ValidationResult("Year is required"));
            }

            if (vehicle.Year <= 2000)
            {
                errors.Add(new ValidationResult("Year must be greater than 2000"));
            }

            if (vehicle.Mileage == 0)
            {
                errors.Add(new ValidationResult("Mileage is required"));
            }

            if (string.IsNullOrEmpty(vehicle.VinNum))
            {
                errors.Add(new ValidationResult("Vin # is required"));
            }

            if (vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP is required"));
            }

            if (vehicle.SalesPrice <= 0)
            {
                errors.Add(new ValidationResult("Sales Price is required"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if(!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file name must be jpg, png, gif, or jpeg"));
                }
            }

            if(vehicle.IsNew && (vehicle.Mileage) > 1000)
            {
                errors.Add(new ValidationResult("New cars must have less than 1000 miles"));
            }

            bool yearError = vehicle.Year < 2000 || vehicle.Year > (Convert.ToInt32(DateTime.Now.Year) + 1);
                if(yearError == true)
                {
                    errors.Add(new ValidationResult("Year must be between 2000 and the current highest year"));
                }


            bool MSRPGreaterThanSalesPrice = vehicle.MSRP > vehicle.SalesPrice;

            if (MSRPGreaterThanSalesPrice == false)
            {
                errors.Add(new ValidationResult("MSRP must be higher than Sales Prices"));
            }

            return errors;
        }
    }
}