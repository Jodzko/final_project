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
            if(_userService.FindUserInDb(usernameClaim.Value).Person != null)
            {
                return Unauthorized("You are not allowed to register more than one person or update information of other users");

            }
            if (_personService.FindPersonInDb(request.personalCode) != null)
            {
                return BadRequest("Person with that code already exists");
            }
            _personService.CreatePerson(request);
            return Ok("Person created succesfully");
        }
        [HttpPut]
        public IActionResult UpdatePersonInformation([FromForm] string personalCode, PersonRequest request)
        {
            //var usernameClaim = User.FindFirst(ClaimTypes.Name);
            //_userService.FindUserInDb(usernameClaim.Value);
            //_personService.UpdatePerson(personalCode, request);
            //return Ok();
        }
        [HttpGet]
        public IActionResult GetPersonInformation([FromBody] string personalCode)
        {
            var person = _personService.FindPersonInDb(personalCode);
            if(person != null)
            {
                return Ok(person);
            }
            return BadRequest("Person not found");
        }
    }
}
