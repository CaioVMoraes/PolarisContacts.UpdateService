using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Repositories
{
    public interface ITelefoneRepository
    {
        Task<bool> UpdateTelefone(Telefone telefone);
        Task<bool> InativaTelefone(int id);
    }
}