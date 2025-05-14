using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Contracts
{
    public record PersonUpdateRequest
    (
        string? name,
        string? surname,
        [RegularExpression(@"^[+]\d{11}$", ErrorMessage = "Must be exactly 12 digits and start with a +.")]
        string? phone,
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        string? email,
        IFormFile? profilePicture
    );
}
