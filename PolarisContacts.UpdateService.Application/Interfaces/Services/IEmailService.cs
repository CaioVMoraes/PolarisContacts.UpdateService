using PolarisContacts.UpdateService.Domain;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IEmailService
    {
        void ValidaEmail(Email email);
        void ValidaInativarEmail(int id);
    }
}
