using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using The_Job_Box.Models;
using The_Job_Box.Models.AccountViewModels;


namespace The_Job_Box.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;
        // private readonly IEmailSend _emailSend;
        // private readonly ISmsSend _smsSend;




        public AccountController(UserManager<AppUser> userManager, ILogger<AccountController> logger, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_emailSend = emailSend;
            //_smsSend = smsSend;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResults =
                    await
                        _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
                            lockoutOnFailure: false);
                if (loginResults.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Information.");
                    return View(model);
                }

            }
            return View(model);
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FullName = model.LastName + model.FirstName

                };

                var identityResults = await _userManager.CreateAsync(identityUser, model.Password);
                if (identityResults.Succeeded)
                {


                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    return View(model);
                    
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Error in Creating my User.");
                    return View(model);
                }

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("Error");

            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View("ConfirmEmail");

        }

        public IActionResult ResetPassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {


                    return RedirectToAction("ResetPassword", "Account");
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (!result.Succeeded) return View(model);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "LoggedIn");
            }

            return View(model);

        }

        public IActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var confirmed = await _userManager.IsEmailConfirmedAsync(user);
                if (user == null || !confirmed)
                {

                    return View("ForgotPasswordConfirmation");
                }
                // Send Email Confirmation

                //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var callbackUrl = Url.Action("ResetPassword", "Main", new { userId = user.Id, code = code },
                //      protocol: HttpContext.Request.Scheme);
                //await
                //    _emailSend.SendEmailAsync(model.Email, "Reset Password",
                //        $"Please Reset you Password by " +
                //        $"clicking this link:<a href='{callbackUrl}'>Link</a>");


            }

            return View(model);

        }

        public IActionResult ForgotPasswordConfirmation()
        {

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> SmsTest()
        {

            //  await _smsSend.SendSmsAsync("14695027582", "This is a test Message");

            //  return RedirectToAction("Index", "Main");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { returnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);

        }


        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                return View(nameof(ExternalLoginFailure));


            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction(nameof(ExternalLoginFailure));

            }

            var result =
                await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
            {

                return Redirect(returnUrl);
            }
            else
            {

                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation",
                    new ExternalLoginConfirmationViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model,
            string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {

                    return View("ExternalLoginFailure");

                }

                var user = new AppUser { UserName = model.Email, Email = model.Email };

                var alreadyRegistered = await _userManager.FindByEmailAsync(model.Email);
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded || alreadyRegistered.UserName != null)

                {
                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded || alreadyRegistered.UserName != null)
                    {

                        await _signInManager.SignInAsync(user, isPersistent: false);

                        RedirectToAction("Index", "LoggedIn");


                    }


                }

            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);

        }

        public IActionResult ExternalLoginFailure()
        {
            return View();

        }
    }
}



//        [TempData]
//        public string ErrorMessage { get; set; }


//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Register()
//        {     
//             return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Login(LoginViewModel model)
//        {
//            if(ModelState.IsValid)
//            {
//                var loginresults = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure:false);

//                if(loginresults.Succeeded)
//                {
//                    RedirectToAction("index", "LoggedIn");
//                }
//            }
//            return View();
//        }

//        public async Task<IActionResult> ForgotPassword()
//        {
//            return View();
//        }
//    }
//}