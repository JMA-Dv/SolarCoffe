using SolarCoffe.Data.Models.Auth;

namespace SolarCoffe.Service.Session
{
    public interface IJWT
    {
        string GenerateToken(ApplicationUser user);
    }
}
