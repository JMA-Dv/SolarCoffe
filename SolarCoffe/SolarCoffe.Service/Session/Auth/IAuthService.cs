
<<<<<<< HEAD
using System.Threading.Tasks;

=======
>>>>>>> afb52e5a2f320b329e790e9a7f015b6171b9a5eb
namespace SolarCoffe.Service.Session.Auth
{
    public interface IAuthService
    {
<<<<<<< HEAD
        Task Register(string firstName, string lastName, string email, string password);

        Task<AuthenticationResult> Login(string email, string password);
=======
        AuthenticationResult Register(string firstName, string lastName, string email, string password);

        AuthenticationResult Login(string email, string password);
>>>>>>> afb52e5a2f320b329e790e9a7f015b6171b9a5eb
    }
}
