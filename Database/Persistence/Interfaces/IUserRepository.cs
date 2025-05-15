using _final_project.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Persistence.Interfaces
{
    public interface IUserRepository
    {
        public void AddUserToDatabase(User user);
        public User FindUserInDatabase(string username);
        public void DeleteUser(User user);
        public void UpdateUser(User user);
    }
}
