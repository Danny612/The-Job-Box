using System.Linq;
using The_Job_Box.Models;
using The_Job_Box.Repository;
using The_Job_Box.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace The_Job_Box.Controllers
{
    public class LoggedInController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProfileRepository _profileRepository;

        public LoggedInController(UserManager<AppUser> userManager, IProfileRepository profileRepository)
        {
            _userManager = userManager;
            _profileRepository = profileRepository;
        }

        public IActionResult Index()
        {
            

            return View();
        }

    }
}
