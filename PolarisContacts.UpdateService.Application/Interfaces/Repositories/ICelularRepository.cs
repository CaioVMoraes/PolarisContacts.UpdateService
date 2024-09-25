using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Repositories
{
    public interface ICelularRepository
    {
        Task<Celular> GetCelularById(int id);
        Task<bool> UpdateCelular(Celular celular);
        Task<bool> InativaCelular(int id);
    }
}
