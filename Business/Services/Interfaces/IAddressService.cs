using _final_project.BusinessLogic.Contracts;
using _final_project.Database.Models;


namespace _final_project.BusinessLogic.Services.Interfaces
{
    public interface IAddressService
    {
        public bool CreateAddress(AddressRequest request, Person person);
        public Address UpdateAddress(Address address, AddressUpdateRequest request);
        public Address FindAddressInDb(int addressId);


    }
}
