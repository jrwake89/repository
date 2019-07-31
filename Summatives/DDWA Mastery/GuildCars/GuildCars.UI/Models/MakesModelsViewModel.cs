using GuildCars.Model;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class MakesModelsViewModel
    {
        public MakesModelsViewModel()
        {
            make = new Make();
            model = new Model.Model();
        }

            
        public IEnumerable<SelectListItem> makeList { get; set; }
        public IEnumerable<Make> makes { get; set; }
        public IEnumerable<GuildCars.Model.Model> models { get; set; }
        public Make make {get; set;}
        public GuildCars.Model.Model model { get; set; }
    }
}