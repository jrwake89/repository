using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Models
{
    public class DVD
    {
        public int DVDID { get; set; }
        public int RatingID { get; set; }
        public string Director { get; set; }
        public string DVDTitle { get; set; }
        public int ReleaseYear { get; set; }
        public string Notes { get; set; }
    }
}
