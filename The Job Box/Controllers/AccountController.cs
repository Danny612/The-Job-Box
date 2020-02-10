using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using The_Job_Box.Models;

namespace The_Job_Box.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<AppUser> UserMgr { get; }
        private SignInManager<AppUser> SignInMgr { get; }

       public AccountController(UserManager<AppUser> userManager,
           SignInManager<AppUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "user already Registered";

                AppUser user = await UserMgr.FindByNameAsync("TestUser");
                if(user == null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser";
                    user.Email = "testemailemail.com";
                    user.FirstName = "Buckley";
                    user.LastName = "Doe";

                    IdentityResult result = await UserMgr.CreateAsync(user, "Test123");
                    ViewBag.Message = "user was created";
                }
            }

            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
    }
}