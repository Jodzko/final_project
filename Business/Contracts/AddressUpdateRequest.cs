using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Contracts
{
    public record AddressUpdateRequest
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AppNumber { get; set; }
    }
}
