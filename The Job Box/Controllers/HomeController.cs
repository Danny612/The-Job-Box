using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using The_Job_Box.Models;

namespace The_Job_Box.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IdentityAppContext _db;


        public HomeController(ILogger<HomeController> logger, IdentityAppContext db)
        {
            _logger = logger;
            _db = db;

            string jobscount = _db.Jobs.Count().ToString() + "+";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Employers()
        {
            return View();
        }

        public IActionResult BlogPosts()
        {
            return View();
        }

        public IActionResult JobCategory()
        {
            return View();
        }

        public IActionResult CVServices()
        {
            return View();
        }

        public IActionResult CarierCenter()
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
