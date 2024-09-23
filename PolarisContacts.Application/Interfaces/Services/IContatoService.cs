using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface IContatoService
    {
        Task<bool> UpdateContato(Contato contato);
        Task<bool> DeleteContato(int id);
    }
}