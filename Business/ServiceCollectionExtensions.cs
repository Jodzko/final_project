using _final_project.BusinessLogic.Services;
using _final_project.BusinessLogic.Services.Interfaces;
using _final_project.Database.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _final_project.BusinessLogic
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
