using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;
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
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
