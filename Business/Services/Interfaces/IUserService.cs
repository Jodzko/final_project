using _final_project.BusinessLogic.Contracts;
using _final_project.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        public bool Signup(UserRequest request);

        public User CreateUser(UserRequest request);
        public bool Login(UserRequest request, out string role);
        public bool DeleteUser(string username);
        public User FindUserInDb(string username);
        public bool ChangePassword(User user, string password);
    }
}
