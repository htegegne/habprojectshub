using AppUserManager.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppUserManager.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AppUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
    }
}
