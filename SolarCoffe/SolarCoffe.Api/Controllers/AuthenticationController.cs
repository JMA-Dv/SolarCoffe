using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolarCoffe.Api.ViewModels;
using SolarCoffe.Service.Session;
using SolarCoffe.Service.Session.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthService _auth;

        public AuthenticationController(IAuthService auth)
        {
            _auth = auth;
        }

        [Route("signIn")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _auth.Register(request.FirstName, request.LastName, request.Email, request.Password);


        }
    }
}
