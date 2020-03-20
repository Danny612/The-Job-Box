using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace The_Job_Box.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RealBasic()
        {
            return View();
        }

        public IActionResult RealStandard()
        {
            return View();
        }

        public IActionResult RealUltimate()
        {
            return View();
        }
    }
}