using Microsoft.AspNetCore.Identity;
using SolarCoffe.Data.Models.Auth;
using System;
using System.Threading.Tasks;

namespace SolarCoffe.Service.Session.Auth
{
    public class AuthenticationService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJWT _jwtGenerator;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJWT jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthenticationResult> Login(string email, string password)
        {
            //var user = await _userManager.FindByEmailAsync(email);
            //if (user == null)
            //{
            //    throw new Exception("Credentials are incorrect");
            //}

            //var valudate = await _signInManager.CheckPasswordSignInAsync()

            throw new NotImplementedException();
        }

        public async Task Register(string firstName, string lastName, string email, string password)
        {
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                throw new Exception("could not create account, user already created");
            }

            var user = new ApplicationUser
            {
                Email = email,
                UserName = firstName,
                FirstName = firstName,
                LastName = lastName,
                BirthDay = DateTime.Now,
            };



            var result = await _userManager.CreateAsync(user, password);


            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }

            var token = _jwtGenerator.GenerateToken(user);


        }


    }
}
