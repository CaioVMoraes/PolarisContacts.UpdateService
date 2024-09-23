using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        Task<bool> UpdateContato(Contato contato);
        Task<bool> DeleteContato(int idContato);
    }
}