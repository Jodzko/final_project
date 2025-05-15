using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Persistence.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _final_project.api.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public UserController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Signup([FromBody] UserRequest request)
        {
            if(_userService.Signup(request) == false)
            {
                return BadRequest("User already exists");
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Login([FromBody] UserRequest request)
        {
            if (!_userService.Login(request, out string role))
            {
                return BadRequest("Bad username or password");
            }
            var token = _jwtService.GetJwtToken(request.username, role);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            return Ok(token);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete([FromBody] UserRequest request)
        {
            if(_userService.DeleteUser(request.username) == true)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPut]
        public IActionResult ChangePassword([FromQuery] string newPassword)
        {
            var usernameClaim = User.FindFirst(ClaimTypes.Name);
            var user = _userService.FindUserInDb(usernameClaim.Value);
            if(_userService.ChangePassword(user, newPassword))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
