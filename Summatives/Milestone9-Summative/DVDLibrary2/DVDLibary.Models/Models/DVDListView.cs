using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Models
{
    public class DVDListView
    {
        public int dvdId { get; set; }
        public string rating { get; set; }
        public string director { get; set; }
        public string dvdTitle { get; set; }
        public int releaseYear { get; set; }
        public string notes { get; set; }
    }
}
