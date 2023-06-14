using System.Threading.Tasks;

namespace SolarCoffe.Service.Session.Auth
{
    public interface IAuthService
    {
        Task Register(string firstName, string lastName, string email, string password);

        Task<AuthenticationResult> Login(string email, string password);
    }
}
