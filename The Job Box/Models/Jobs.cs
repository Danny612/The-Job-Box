using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models
{
    public class Jobs
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Telephone { get; set; }
        [Required]
        public string JobName { get; set; }

       
      
        public int JobCategoryId { get; set; }

        [ForeignKey("JobCategoryId")]
        public virtual JobCategory Category { get; set; }

       
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubJobCategory SubCategory { get; set; }

        public int JobLocation { get; set; }


        [ForeignKey("JobLocation")]
        public virtual JobLocation Location { get; set; }
  
        public double Salary { get; set; }
       
        public String Description { get; set; }
        public String Summary { get; set; }

    }
}
