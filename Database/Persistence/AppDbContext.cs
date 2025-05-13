using _final_project.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(x => x.Address)
                .WithOne(x => x.Person)
                .HasForeignKey<Address>(x => x.PersonId);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Person)
                .WithOne(x => x.User)
                .HasForeignKey<Person>(x => x.Username);
        }
    }
}
