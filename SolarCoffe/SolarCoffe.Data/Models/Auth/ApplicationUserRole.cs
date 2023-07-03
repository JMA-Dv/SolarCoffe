using Microsoft.AspNetCore.Identity;
namespace SolarCoffe.Data.Models.Auth
{
    public class ApplicationUserRole:IdentityUserRole<string>
    {
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
