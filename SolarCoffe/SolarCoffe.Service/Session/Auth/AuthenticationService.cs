<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
=======
﻿using System;
using System.Collections.Generic;
using System.Text;
>>>>>>> afb52e5a2f320b329e790e9a7f015b6171b9a5eb

namespace SolarCoffe.Service.Session.Auth
{
    public class AuthenticationService : IAuthService
    {

<<<<<<< HEAD
        
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;


        public AuthenticationService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
            
            var user = new IdentityUser
            {
                Email = email,
                UserName = firstName,
            };



            var result = await _userManager.CreateAsync(user,password);

            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }

         
=======


        public AuthenticationResult Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            throw new NotImplementedException();
>>>>>>> afb52e5a2f320b329e790e9a7f015b6171b9a5eb
        }
    }
}
