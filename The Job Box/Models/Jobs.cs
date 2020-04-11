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
      
        public int ID { get; set; }
        public Guid Job_ID { get; set; }
        [Required]
        public string JobName { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int JobCategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual JobCategory Category { get; set; }

        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubJobCategory SubCategory { get; set; }
        public virtual JobLocation Location { get; set; }
        [Display(Name ="Job Salary")]
        public double Salary { get; set; }
        [Required]
        public String Description { get; set; }
        public String Summary { get; set; }



    }
}
