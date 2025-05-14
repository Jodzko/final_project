using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace _final_project.api.Controllers
{
    [Authorize]
    [Route("[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IUserService _userService;

        public PersonController(IPersonService personService, IUserService userService)
        {
            _personService = personService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult AddPersonInformation([FromForm] PersonRequest request)
        {            
            var usernameClaim = User.FindFirst(ClaimTypes.Name);
            var person = _userService.FindUserInDb(usernameClaim.Value).PersonalCode;
            if(person != null)
            {
                return Unauthorized("You are not allowed to register more than one person or update information of other users");
            }
            if (_personService.FindPersonInDb(request.personalCode) != null)
            {
                return BadRequest("Person with that code already exists");
            }
            var user = _userService.FindUserInDb(usernameClaim.Value);
            _personService.CreatePerson(request, user);
            return Ok("Person created succesfully");
        }
        [HttpPut]
        public IActionResult UpdatePersonInformation([FromForm] PersonUpdateRequest request)
        {
            var usernameClaim = User.FindFirst(ClaimTypes.Name);
            var user = _userService.FindUserInDb(usernameClaim.Value);
            if(user != null)
            {
            if(user.PersonalCode == null)
            {
                return BadRequest("You must first a create a person for your user");
            }
            if(user.Username != usernameClaim.Value)
            {
                return Unauthorized("You can only change your own information");
            }
            _personService.UpdatePerson(user.Person, request);
            return Ok();
            }
            return BadRequest("You must first register a user");
        }
        [HttpGet]
        public IActionResult GetPersonInformation([FromQuery] string personalCode)
        {
            return Ok(_personService.GetPerson(personalCode));
        }
    }
}
