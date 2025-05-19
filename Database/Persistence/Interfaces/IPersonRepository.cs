using _final_project.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Persistence.Interfaces
{
    public interface IPersonRepository
    {
        public void AddOrUpdatePersonInDb(Person person);
        public Person FindPersonInDb(string personalCode);
        public void DeletePerson(Person person);
        public bool DoesEmailExist(string email);


    }
}
