using _final_project.Database.Persistence;
using _final_project.Database.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
