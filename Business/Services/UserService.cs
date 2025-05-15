using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPersonRepository _personRepo;
        private readonly IAddressRepository _addressRepo;

        public UserService(IUserRepository userRepo, IPersonRepository personRepo, IAddressRepository addressRepo)
        {
            _userRepo = userRepo;
            _personRepo = personRepo;
            _addressRepo = addressRepo;
        }
        public bool Signup(UserRequest request)
        {
            var existingUser = _userRepo.FindUserInDatabase(request.username);
            if (existingUser != null)
            {
                return false;
            }
            else
            {
                var user = CreateUser(request);
                _userRepo.AddUserToDatabase(user);
                return true;
            }
        }
        public User CreateUser(UserRequest request)
        {
            CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var newUser = new User()
            {
                Username = request.username,
                Password = passwordHash,
                Salt = passwordSalt,
                Role = "User"
            };
            return newUser;
        }
        public bool Login(UserRequest request, out string role)
        {
            var account = _userRepo.FindUserInDatabase(request.username);

            if (account == null)
            {
                role = string.Empty;
                return false;
            }
            role = account.Role;
            if (VerifyPasswordHash(request.password.ToString(), account.Password, account.Salt))
            {
                return true;
            }
            return false;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
        public bool DeleteUser(string username)
        {
            var user = _userRepo.FindUserInDatabase(username);
            if(user != null)
            {
                if(user.Role == "Admin")
                {
                    return false;
                }
                var person = _personRepo.FindPersonInDb(user.Person.PersonalCode);
                if (person != null)
                {
                    var address = _addressRepo.FindAddressInDb(person.Address.Id);
                    if(address != null)
                    {
                        _addressRepo.DeleteAddress(address);
                    }
                    _personRepo.DeletePerson(person);
                }
                _userRepo.DeleteUser(user);
                return true;
            }
            return false;
        }
        public User FindUserInDb(string username)
        {
           return _userRepo.FindUserInDatabase(username);
        }
        public bool ChangePassword(User user, string password)
        {
           if(user != null)
            {
                CreatePasswordHash(password, out byte[]passwordHash, out byte[] passwordSalt);
                if(passwordHash == user.Password || passwordSalt == user.Salt)
                {
                    return false;
                }
                user.Password = passwordHash;
                user.Salt = passwordSalt;
                _userRepo.UpdateUser(user);
                return true;
            }
            return false;
        }
    }
}
