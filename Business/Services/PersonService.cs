using _final_project.BusinessLogic.Contracts;
using _final_project.BusinessLogic.Extensions;
using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;


namespace _final_project.BusinessLogic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        private readonly IImageService _imageService;

        public PersonService(IPersonRepository personRepo, IImageService image, IUserService userService)
        {
            _personRepo = personRepo;
            _imageService = image;
        }
        public bool CreatePerson(PersonRequest request, User user)
        {
            if (_personRepo.FindPersonInDb(request.personalCode) != null)
            {
                return false;
            }
            var person = new Person
            {
                Email = request.email,
                Name = request.name,
                Surname = request.surname,
                PersonalCode = request.personalCode,
                PhoneNumber = request.phone,
                Picture = _imageService.CreatePicture(request.profilePicture),
                User = user,
            };
            user.PersonalCode = person.PersonalCode;
            user.Person = person;
            _personRepo.AddOrUpdatePersonInDb(person);
            return true;
        }
        public Person FindPersonInDb(string personalCode)
        {
            return _personRepo.FindPersonInDb(personalCode);
        }
        public void DeletePerson(string personalCode)
        {
            var person = _personRepo.FindPersonInDb(personalCode);
            if(person != null)
            {
                _personRepo.DeletePerson(person);
            }
        }
        public void UpdatePerson(Person personInDb, PersonUpdateRequest request)
        {
            if(personInDb != null)
            {
                if(!request.name.IsNullOrBlank() && request.name != personInDb.Name)
                {
                    personInDb.Name = request.name;
                }
                if (!request.surname.IsNullOrBlank() && request.surname != personInDb.Surname)
                {
                    personInDb.Surname = request.surname;
                }
                if (!request.phone.IsNullOrBlank() && request.phone != personInDb.PhoneNumber)
                {
                    personInDb.PhoneNumber = request.phone;
                }
                if (!request.email.IsNullOrBlank() && request.email != personInDb.Email)
                {
                    personInDb.Email = request.email;
                }
            }
            _personRepo.AddOrUpdatePersonInDb(personInDb);
        }
        public PersonResponse GetPerson(string personalCode)
        {
            var personInDb = _personRepo.FindPersonInDb(personalCode);
            if(personInDb != null)
            {
            var person = new PersonResponse
            {
                personalCode = personInDb.PersonalCode,
                name = personInDb.Name,
                surname = personInDb.Surname,
                phone = personInDb.PhoneNumber,
                email = personInDb.Email,
                profilePicture = personInDb.Picture,
                city = personInDb.Address.City,
                street = personInDb.Address.Street,
                houseNumber = personInDb.Address.HouseNumber,
                appNumber = personInDb.Address.AppNumber,
            };
            return person;
            }
            return null;
        }
    }
}
