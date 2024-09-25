using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        Task<bool> UpdateContato(Contato contato);
        Task<bool> InativaContato(int idContato);
    }
}