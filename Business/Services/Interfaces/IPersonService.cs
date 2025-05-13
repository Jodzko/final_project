using _final_project.BusinessLogic.Contracts;
using _final_project.Database.Models;


namespace _final_project.BusinessLogic.Services.Interfaces
{
    public interface IPersonService
    {
        public bool CreatePerson(PersonRequest request);
        public void DeletePerson(string personalCode);
        public Person FindPersonInDb(string personalCode);
        public void UpdatePerson(string personalCode, PersonRequest request);
    }
}
