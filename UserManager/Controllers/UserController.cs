using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System;
using UserManager.Models;
using UserManager.Models.ViewModels;
using UserManager.Services;

namespace UserManager.Controllers
{
    // [Area("Identity")]
    public class UserController : Controller
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IApplicationUserRepository userRepository, SignInManager<ApplicationUser> signInManager, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    NormalizedUserName = model.UserName.ToUpper(),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address // Assuming Address is part of the ApplicationUser model
                };

                var result = await _userRepository.CreateAsync(user, model.Password);
                if (result != null) // Ensure this checks if registration was successful
                {
                    _logger.LogInformation("User registered successfully.");

                    // Automatically sign in the user
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect to the home page or a different page after login
                    return RedirectToAction("Index", "Home"); // Adjust the action and controller as needed
                }
                else
                {
                    _logger.LogError("User registration failed.");
                    ModelState.AddModelError(string.Empty, "Failed to register user.");
                }
            }
            return View(model);
        }
    }
}
