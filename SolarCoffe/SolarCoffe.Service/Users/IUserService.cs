using SolarCoffe.Data.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolarCoffe.Service.Users
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetUserByEmail(string email);
        Task Add(ApplicationUser user);
    }
}
