
namespace _final_project.BusinessLogic.Contracts
{
    public record AddressRequest
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int AppNumber { get; set; }
    }
}
