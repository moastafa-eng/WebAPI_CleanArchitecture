using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAPI_CleanArchitecture.Application.Features.Products;

namespace WebAPI_CleanArchitecture.Application
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {

            #region Mapping Configurations
            services.AddAutoMapper(config =>
          {
              config.AddProfile<ProductMapper>();
          }, Assembly.GetExecutingAssembly()); 
            #endregion


            return services;
        }
    }
}
