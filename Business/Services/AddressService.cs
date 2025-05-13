using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Extensions;
using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;


namespace _final_project.BusinessLogic.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepo;

        public AddressService(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public Address CreateAddress(AddressRequest request)
        {
            var address = new Address
            {
                City = request.City,
                Street = request.Street,
                AppNumber = request.AppNumber,
                HouseNumber = request.HouseNumber
            };
            _addressRepo.AddOrUpdateAddress(address);
            return address;
        }
        public Address UpdateAddress(int addressId, AddressRequest request)
        {
            var addressInDb = FindAddressInDb(addressId);
            if(addressInDb != null)
            {
                if(!request.City.IsNullOrBlank() && request.City != addressInDb.City)
                    {
                        addressInDb.City = request.City;
                    }
                if(!request.Street.IsNullOrBlank() && request.Street != addressInDb.Street)
                    {
                        addressInDb.Street = request.Street;
                    }
                if(!request.HouseNumber.IsNullOrZero() && request.HouseNumber != addressInDb.HouseNumber)
                    {
                        addressInDb.HouseNumber = request.HouseNumber;
                    }
                if(!request.AppNumber.IsNullOrZero() && request.AppNumber != addressInDb.AppNumber)
                    {
                        addressInDb.AppNumber = request.AppNumber;
                    }
            }
            return addressInDb;
        }
        public Address FindAddressInDb(int addressId)
        {
            return _addressRepo.FindAddressInDb(addressId);
        }
    }
}
