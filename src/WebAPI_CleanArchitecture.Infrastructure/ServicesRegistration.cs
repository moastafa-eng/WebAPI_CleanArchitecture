using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Infrastructure.Repositories;
using WebAPI_CleanArchitecture.Infrastructure.UnitOfWorks;

namespace WebAPI_CleanArchitecture.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection LoadInfrastructureServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            AddDbConnection(services, config);
            AddServicesToDIContainer(services);

            return services;
        }





        private static IServiceCollection AddDbConnection(
            IServiceCollection services, 
            IConfiguration config)
        {
            // Add DbContext with an options 
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DatabaseConnection"));
            });

            return services;
        }

        private static IServiceCollection AddServicesToDIContainer(
            IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
