using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models
{
    public class JobLocation
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Job Location Name")]
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }
}
