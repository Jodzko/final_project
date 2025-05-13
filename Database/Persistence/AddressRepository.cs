using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _final_project.Database.Persistence
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public Address FindAddressInDb(int addressId)
        {
            return _context.Addresses.FirstOrDefault( x => x.Id == addressId);
        }
        public void AddOrUpdateAddress(Address address)
        {
            var addressInDb = FindAddressInDb(address.Id);
            if(addressInDb != null)
            {
                _context.Addresses.UpdateRange(addressInDb, address);
                _context.SaveChanges();
            }
            else
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
        }
    }
}
