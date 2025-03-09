using AppUserManager.Models.Entities;
using AppUserManager.Models.ViewModels;
using AppUserManager.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppUserManager.Controllers
{
    public class AppUserController : Controller
    {
        private IAppUserService _appUserService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AppUserController(IAppUserService appUserService, SignInManager<ApplicationUser> signInManager)
        {
            _appUserService = appUserService;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
                // Map RegisterViewModel to ApplicationUser
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CustomUsername = model.CustomUserName, // Use custom username
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    UserName = model.Email,
                };

                var result = await _appUserService.RegisterUserAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Optionally, log in the user after registration
                     await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect to a different page or show a success message
                    return RedirectToAction("Index", "Home");
                }

                // Add errors to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
