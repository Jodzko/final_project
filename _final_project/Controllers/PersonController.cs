using _final_project.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _final_project.api.Controllers
{
    //[Authorize]
    [Route("[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpPut]
        public IActionResult AddPersonInformation([FromForm] PersonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
