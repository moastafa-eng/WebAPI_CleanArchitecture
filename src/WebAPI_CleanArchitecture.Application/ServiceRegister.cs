using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAPI_CleanArchitecture.Application.Abstraction.Emailing;
using WebAPI_CleanArchitecture.Application.Features.Products;
using WebAPI_CleanArchitecture.Domain.Abstraction;

namespace WebAPI_CleanArchitecture.Application
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            AddServicesToDIContainer(services);

            return services;
        }

        private static void AddServicesToDIContainer(IServiceCollection services)
        {


            #region Mapping Configurations
            services.AddAutoMapper(config =>
            {
                config.AddProfile<ProductMapper>();
            }, Assembly.GetExecutingAssembly());


            #endregion
            #region Mediator Pattern Configurations
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            #endregion

        }
    }
}
