
using WebAPI_CleanArchitecture.APIs.Extensions;
using WebAPI_CleanArchitecture.Application;
using WebAPI_CleanArchitecture.Infrastructure;

namespace WebAPI_CleanArchitecture.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.LoadInfrastructureServices(builder.Configuration);

                

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
