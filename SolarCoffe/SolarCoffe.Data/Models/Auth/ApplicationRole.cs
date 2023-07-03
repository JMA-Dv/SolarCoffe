using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SolarCoffe.Data.Models.Auth
{
    public class ApplicationRole:IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
