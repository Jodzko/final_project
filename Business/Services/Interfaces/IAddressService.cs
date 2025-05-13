using _final_project.BusinessLogic.Contracts;
using _final_project.Database.Models;


namespace _final_project.BusinessLogic.Services.Interfaces
{
    public interface IAddressService
    {
        public Address CreateAddress(AddressRequest request);
        public Address UpdateAddress(int addressId, AddressRequest request);
        public Address FindAddressInDb(int addressId);


    }
}
