using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface ITelefoneService
    {
        Task UpdateTelefone(Telefone telefone);
        Task DeleteTelefone(int id);
    }
}