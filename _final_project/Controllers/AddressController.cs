using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Services;
using _final_project.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _final_project.api.Controllers
{
    [Authorize]
    [Route("[action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IPersonService _personService;
        private readonly IUserService _userService;

        public AddressController(IAddressService addressService, IPersonService personService, IUserService userService)
        {
            _addressService = addressService;
            _personService = personService;
            _userService = userService;
        }
        [HttpPost]
        public IActionResult CreateAddress([FromForm] AddressRequest request)
        {
            var usernameClaim = User.FindFirst(ClaimTypes.Name);
            var user = _userService.FindUserInDb(usernameClaim.Value);
            if(user != null)
            {
                var person = user.Person;
                if(person == null)
                {
                    return BadRequest("You must first add a Person to this user");
                }
                if (person.Address != null )
                {
                    return Unauthorized("You are not allowed to register more than one address");
                }
                if(_addressService.CreateAddress(request, person))
                { 
                    return Ok();
                }
            }
            return BadRequest("You must first register a user and add a person to it");
        }
        [HttpPut]
        public IActionResult UpdateAddress([FromForm] AddressUpdateRequest request)
        {
            var usernameClaim = User.FindFirst(ClaimTypes.Name);
            var user = _userService.FindUserInDb(usernameClaim.Value);
            if (user != null)
            {
                var person = user.Person;
                if (person == null)
                {
                    return BadRequest("You must first add a Person to this user");
                }
                if(person.Address == null)
                {
                    return BadRequest("You must first add an address before updating it");
                }
                _addressService.UpdateAddress(person.Address, request);
                return Ok();
            }
            return BadRequest("You must first register a user and add a person to it");
        }
    }
}
