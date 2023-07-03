using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SolarCoffe.Data.Models.Auth
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
