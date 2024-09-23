using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task<bool> UpdateEmail(Email email);
        Task<bool> DeleteEmail(int id);
    }
}
