using WebAPI_CleanArchitecture.Application.Abstraction.Emailing;

namespace WebAPI_CleanArchitecture.Infrastructure.Services.Emailing
{
    public class EmailService : IEmailService
    {
        public Task SendAsync()
        {
            return Task.CompletedTask;
        }
    }
}
