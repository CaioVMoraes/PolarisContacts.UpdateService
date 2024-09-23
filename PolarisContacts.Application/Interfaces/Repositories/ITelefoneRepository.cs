using PolarisContacts.Domain;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface ITelefoneRepository
    {
        Task<bool> UpdateTelefone(Telefone telefone);
        Task<bool> DeleteTelefone(int id);
    }
}