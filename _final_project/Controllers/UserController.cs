using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Persistence.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace _final_project.api.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepo;

        public UserController(IJwtService jwtService, IUserService userService, IUserRepository userRepo)
        {
            _jwtService = jwtService;
            _userService = userService;
            _userRepo = userRepo;
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
    }
}
