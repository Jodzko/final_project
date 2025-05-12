using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Models
{
    public class Address
    {
        public int Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AppNumber { get; set; }
    }
}
