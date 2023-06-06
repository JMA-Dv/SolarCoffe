using SolarCoffe.Data.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffe.Service.Users
{
    public interface IUserService
    {
        Task<User?> GetUserByEmail(string email);
        Task Add(User user);
    }
}
