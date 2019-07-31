using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class PurchaseViewModel:IValidatableObject
    {
        public PurchaseViewModel()
        {
            Sale = new Sales();
            VehicleDetails = new VehicleDetailsRequest();
        }

        public VehicleDetailsRequest VehicleDetails{get; set;}
        public Sales Sale { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Sale.Street1))
            {
                errors.Add(new ValidationResult("Street 1 is a required field."));
            }

            if (string.IsNullOrEmpty(Sale.City))
            {
                errors.Add(new ValidationResult("City is a required field."));
            }

            if (Sale.ZipCode == 0 || Sale.ZipCode.ToString().Length != 5 )
            {
                errors.Add(new ValidationResult("Enter a valid zipcode"));
            }

            if (Sale.PurchasePrice == 0)
            {
                errors.Add(new ValidationResult("Enter a purchase price"));
                
            }

            if (string.IsNullOrEmpty(Sale.Email) && string.IsNullOrEmpty(Sale.Phone))
            {   
                        errors.Add(new ValidationResult("Enter at least your email or phone number"));
            }
            else
            {
                var emailCheck = new EmailAddressAttribute();
                bool success = emailCheck.IsValid(Sale.Email);

                if (success == false)
                {
                    errors.Add(new ValidationResult("Enter a valid email address"));
                }
            }

            return errors;
        }
    }
}