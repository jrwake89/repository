using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            User = new ApplicationUser();
            Roles = new List<SelectListItem>();
        }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public ApplicationUser User { get; set; }

    }
}