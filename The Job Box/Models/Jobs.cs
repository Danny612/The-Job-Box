using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models
{
    public class Jobs
    {
      
        public int ID { get; set; }

        public Guid Job_ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Location { get; set; }
        public double Salary { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Summary { get; set; }



    }
}
