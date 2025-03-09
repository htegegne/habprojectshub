using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManager.Models;
using UserManager.Models.ViewModels;

namespace UserManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserManager.Models.ViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    }
}
