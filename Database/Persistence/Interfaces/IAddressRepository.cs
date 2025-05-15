using _final_project.Database.Models;


namespace _final_project.Database.Persistence.Interfaces
{
    public interface IAddressRepository
    {
        public Address FindAddressInDb(int addressId);
        public void AddOrUpdateAddress(Address address);
        public void DeleteAddress(Address address);

    }
}
