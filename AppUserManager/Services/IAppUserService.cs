using AppUserManager.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppUserManager.Services
{
    public interface IAppUserService
    {
        Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password);
    }
}
