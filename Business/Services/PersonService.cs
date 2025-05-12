using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;

        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        public void DeletePerson(string personalCode)
        {
            var person = _personRepo.FindPersonInDb(personalCode);
            if(person != null)
            {
                _personRepo.DeletePerson(person);
            }
        }
    }
}
