using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Models
{
    public class Person
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        [Key]
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public required byte[] Picture { get; set; }
        public Address? Address { get; set; }
        public int? AddressId { get; set; }
        public User User { get; set; }
        public string Username { get; set; }
    }
}
