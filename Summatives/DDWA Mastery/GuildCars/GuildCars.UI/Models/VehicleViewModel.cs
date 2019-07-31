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
    public class VehicleViewModel:IValidatableObject
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


        public VehicleViewModel()
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


        public VehicleViewModel GetLists()
        {
            VehicleViewModel viewModel = new VehicleViewModel();

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

            if (vehicle.Year == 0)
            {
                errors.Add(new ValidationResult("Year is required"));
            }

            if (vehicle.Mileage <= 0)
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

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file name must be jpg, png, gif, or jpeg"));
                }
            }

            else
            {
                errors.Add(new ValidationResult("Image is required"));
            }

            if (vehicle.IsNew == true && vehicle.Mileage > 1000)
            {
                errors.Add(new ValidationResult("New cars must have less than 1,000 miles"));
            }

            bool yearError = vehicle.Year < 2000 || vehicle.Year > (DateTime.Now.Year) + 1;
            if (yearError == true)
            {
                errors.Add(new ValidationResult("Year must be between 2000 and the current highest year"));
            }

            if (vehicle.SalesPrice < 0)
            {
                errors.Add(new ValidationResult("Sales price must be greater than 0"));
            }

            if (vehicle.MSRP < 0)
            {
                errors.Add(new ValidationResult("MSRP must be greater than 0"));
            }

            bool MSRPLessThanSalesPrice = (vehicle.MSRP < vehicle.SalesPrice);

            if (MSRPLessThanSalesPrice == true)
            {
                errors.Add(new ValidationResult("MSRP must be higher than Sales Prices"));
            }

            if(vehicle.ModelId == 0)
            {
                errors.Add(new ValidationResult("Must select Make then Model"));
            }

            return errors;
        }
    }
}
