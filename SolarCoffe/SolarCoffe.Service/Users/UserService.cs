<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> afb52e5a2f320b329e790e9a7f015b6171b9a5eb
using SolarCoffe.Data;
using SolarCoffe.Data.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffe.Service.Users
{
<<<<<<< HEAD
    public class UserService 
    {
    } 
=======
    public class UserService : IUserService
    {
        private readonly SolarCoffeDbContext _context;

        public UserService(SolarCoffeDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            var users = new Microsoft.AspNetCore.Identity.IdentityUser()
            {
                Email = user.Email,
                UserName = user.Email,
                
            }
            await _context.Users.AddAsync(user);   
         }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await  _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
>>>>>>> afb52e5a2f320b329e790e9a7f015b6171b9a5eb
}
