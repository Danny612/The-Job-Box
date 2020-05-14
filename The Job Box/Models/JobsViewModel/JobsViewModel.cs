using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models.JobsViewModel
{
    public class JobsViewModel
    {
        public Jobs Jobs { get; set; }
        public IEnumerable<JobCategory> Category { get; set; }
        public IEnumerable<SubJobCategory> SubCategory { get; set; }


        //public int ID { get; set; }

        //[Required]
        //[Display(Name = "Company Name")]
        //public string CompanyName { get; set; }
        //[Required]
        //[Display(Name = "Company Telephone")]
        //public string Telephone { get; set; }
        //[Required]
        //[Display(Name = "Name of Job")]
        //public string JobName { get; set; }

        //[Required]
        //[Display(Name = "Category")]
        //public int JobCategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public virtual JobCategory Category { get; set; }

        //[Display(Name = "SubCategory")]
        //public int SubCategoryId { get; set; }

        //[ForeignKey("SubCategoryId")]
        //public virtual SubJobCategory SubCategory { get; set; }
        //public virtual JobLocation Location { get; set; }
        //[Display(Name ="Job Salary")]
        //public double Salary { get; set; }
        //[Required]
        //public String Description { get; set; }
        //public String Summary { get; set; }



    }
}
