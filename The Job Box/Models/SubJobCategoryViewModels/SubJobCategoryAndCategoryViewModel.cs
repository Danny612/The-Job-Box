using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using The_Job_Box.Models;

namespace The_Job_Box.Models.SubJobCategoryViewModels
{
    public class SubCategoryAndCategoryViewModel
    {
        public SubJobCategory SubCategory { get; set; }
        public IEnumerable<JobCategory> CategoryList { get; set; }

        public List<string> SubCategoryList { get; set; }

        [Display(Name ="New Sub Category")]
        public bool isNew { get; set; }
        public string StatusMessage { get; set; }

    }
}
