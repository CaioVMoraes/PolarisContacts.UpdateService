using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IContatoService
    {
        Task<bool> UpdateContato(Contato contato);
        Task<bool> InativaContato(int id);
    }
}