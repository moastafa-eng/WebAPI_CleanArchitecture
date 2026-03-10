using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI_CleanArchitecture.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection LoadInfrastructureServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            AddDbConnection(services, config);

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
    }
}
