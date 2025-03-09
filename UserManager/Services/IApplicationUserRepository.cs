using UserManager.Models;

namespace UserManager.Services
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
    }
}
