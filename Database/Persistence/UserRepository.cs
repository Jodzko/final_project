using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUserToDatabase(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User FindUserInDatabase(string username)
        {
            return _context.Users
                .Include(x => x.Person)
                .Include(x => x.Person.Address)
                .FirstOrDefault(x => x.Username == username);
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _context.Users.UpdateRange(user);
            _context.SaveChanges();
        }
    }
}
