using SolarCoffe.Data.Models.Auth;

namespace SolarCoffe.Service.Session.Auth
{
    public class AuthenticationResult
    {
        public User  User { get; set; }
        public string Token { get; set; }

    }
}