using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibary.Models.Models
{
    public class DVDRequest
    {
        [Required]
        public int DvdId { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public int RatingId { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string DvdTitle { get; set; }
        [Required]
        public string Notes { get; set; }

    }

}
