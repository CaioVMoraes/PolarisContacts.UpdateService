using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task UpdateEmail(Email email);
        Task DeleteEmail(int id);
    }
}
