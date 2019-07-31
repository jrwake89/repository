using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ContactViewModel : IValidatableObject
    {
        public ContactViewModel()
        {
            VinNum = "";
        }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactMessage { get; set; }
        public string VinNum { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ContactName))
            {
                errors.Add(new ValidationResult("Name is a required field."));
            }

            if(string.IsNullOrEmpty(ContactMessage))
            {
                errors.Add(new ValidationResult("Message is a required field."));
            }

            
            if(string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Phone))
            {

                    errors.Add(new ValidationResult("Enter your email or phone number"));
            }

            return errors;
        }
    }
}