namespace WebAPI_CleanArchitecture.Application.Abstraction.Emailing
{
    public interface IEmailService
    {
        Task SendAsync();
    }
}
