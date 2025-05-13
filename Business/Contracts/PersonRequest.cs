using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace _final_project.BusinessLogic.Contracts
{
    public record PersonRequest(
        string name,
        string surname,
        [RegularExpression(@"^[34]\d{10}$", ErrorMessage = "Must be exactly 11 digits and start with 3 or 4.")]   
        string personalCode,
        [RegularExpression(@"^[+]\d{11}$", ErrorMessage = "Must be exactly 12 digits and start with a +.")]
        string phone,
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        string email,
        [Required]
        IFormFile profilePicture 
        //AddressRequest address
        );
}
