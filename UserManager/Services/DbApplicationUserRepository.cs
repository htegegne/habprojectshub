using Microsoft.AspNetCore.Identity;
using UserManager.Data;
using UserManager.Models;

namespace UserManager.Services
{
    public class DbApplicationUserRepository : IApplicationUserRepository
    {
        private ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        public DbApplicationUserRepository(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;

        }
    }
}
