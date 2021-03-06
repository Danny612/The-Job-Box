﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Job_Box.Models
{
    public class AppUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String FullName { get; set; }
        public String CompanyName { get; set; }
        public String Position { get; set; }
    }
}
