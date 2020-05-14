using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Job_Box.Models.JobsViewModel;

namespace The_Job_Box.Models
{
    public class IdentityAppContext : IdentityDbContext<AppUser>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options):base(options)
        {

        }

        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobCategory> Category { get; set; }
        public DbSet<SubJobCategory> SubCategory { get; set; }

        public DbSet<Blogposts> Blogposts { get; set; }
       

    }
}
