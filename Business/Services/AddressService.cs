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
        private readonly IPersonRepository _personRepo;

        public AddressService(IAddressRepository addressRepo, IPersonRepository personRepo)
        {
            _addressRepo = addressRepo;
            _personRepo = personRepo;
        }

        public bool CreateAddress(AddressRequest request, Person person)
        {
            if(person.Address == null)
            {
                var address = new Address
                {
                    City = request.City,
                    Street = request.Street,
                    AppNumber = request.AppNumber,
                    HouseNumber = request.HouseNumber,
                    Person = person,
                    PersonalCode = person.PersonalCode
                };
                _addressRepo.AddOrUpdateAddress(address);
                person.Address = address;
                person.AddressId = address.Id;
                _personRepo.AddOrUpdatePersonInDb(person);
            return true;
            }
            return false;
        }
        public Address UpdateAddress(Address addressInDb, AddressUpdateRequest request)
        {
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
            _addressRepo.AddOrUpdateAddress(addressInDb);
            }
            return addressInDb;
        }
        public Address FindAddressInDb(int addressId)
        {
            return _addressRepo.FindAddressInDb(addressId);
        }
    }
}
