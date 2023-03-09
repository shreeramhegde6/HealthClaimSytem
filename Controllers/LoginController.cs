using HealthClaimApp.Models;
using HealthClaimApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClaimApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        HealthclaimAppContext db;
        private IConfiguration _config;
        ILoginService loginService;

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost]
        [Route("login-user")]
        public IActionResult Login(TblLogin user)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = loginService.AuthenticateUser(user, false);
                if (user != null)
                {
                    var tokenString = loginService.GenerateToken(userdata);
                    response = Ok(new { token = tokenString, role = userdata.UserRole });
                }
                return response;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
        [HttpPost]
        [Route("register-user")]
        public IActionResult Register([FromBody] TblLogin user)
        {
            try
            {
                IActionResult response = Unauthorized();
                var userdata = loginService.AuthenticateUser(user, true);
                if (user != null)
                {
                    var tokenString = loginService.GenerateToken(userdata);
                    response = Ok(new { token = tokenString, role = userdata.UserRole });
                }
                return response;
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

    }
}
