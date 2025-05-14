using _final_project.Database.Models;
using _final_project.Database.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Persistence
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddOrUpdatePersonInDb(Person person)
        {
            if (person != null)
            {
                var personInDatabase = FindPersonInDb(person.PersonalCode);
                if (personInDatabase == null)
                {
                    _context.People.Add(person);
                    _context.SaveChanges();
                }
                else
                {
                    _context.People.UpdateRange(personInDatabase, person);
                    _context.SaveChanges();
                }
            }
        }
        public Person FindPersonInDb(string personalCode)
        {
            return _context.People
                .Include(x => x.User)
                .Include(x => x.Address)
                .FirstOrDefault(x => x.PersonalCode == personalCode);
        }
        public void DeletePerson(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }
}
