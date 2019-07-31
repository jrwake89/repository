using GuildCars.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialViewModel
    {
        public SpecialViewModel()
        {
            newSpecial = new Special();
        }
        public IEnumerable<Special> specials { get; set; }
        public Special newSpecial { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(newSpecial.SpecialTitle))
            {
                errors.Add(new ValidationResult("The title is a required field."));
            }

            if (string.IsNullOrEmpty(newSpecial.SpecialDesc))
            {
                errors.Add(new ValidationResult("The description is a required field."));
            }

            return errors;
        }
    }
}