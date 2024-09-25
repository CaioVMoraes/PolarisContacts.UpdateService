using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task UpdateEmail(Email email);
        Task InativaEmail(int id);
    }
}
