using _final_project.BusinessLogic.Services;
using _final_project.BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace _final_project.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}
