﻿using Microsoft.AspNetCore.Identity;

namespace UserManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
       
        public string Address { get; set; }
    }
}
