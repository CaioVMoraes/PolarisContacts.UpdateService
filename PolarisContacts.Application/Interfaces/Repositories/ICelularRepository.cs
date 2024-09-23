using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface ICelularRepository
    {
        Task<bool> UpdateCelular(Celular celular);
        Task<bool> DeleteCelular(int id);
    }
}
