using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models
{
    public class Blogposts
    {
        
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public List<SubJobCategory> Tags { get; set; }

        public DateTime CreateTime { get; set; }

        public string ImageUrl { get; set; }

    }
}
