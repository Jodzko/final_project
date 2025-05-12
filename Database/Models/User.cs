using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
        public Person Person { get; set; }
    }
}
