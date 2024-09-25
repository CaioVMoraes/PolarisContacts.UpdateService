using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<bool> UpdateEmail(Email email);
        Task<bool> InativaEmail(int id);
    }
}
