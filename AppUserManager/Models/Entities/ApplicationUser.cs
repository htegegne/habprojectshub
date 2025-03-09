using Microsoft.AspNetCore.Identity;

namespace AppUserManager.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? UserType { get; set; }

       
        public string? CustomUsername { get; set; }

    }
}
