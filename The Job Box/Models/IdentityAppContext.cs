using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models
{
    public class IdentityAppContext : IdentityDbContext<AppUser>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options):base(options)
        {

        }
    }
}
