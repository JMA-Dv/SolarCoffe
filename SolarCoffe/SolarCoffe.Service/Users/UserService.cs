using Microsoft.EntityFrameworkCore;
using SolarCoffe.Data;
using SolarCoffe.Data.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffe.Service.Users
{
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
}
