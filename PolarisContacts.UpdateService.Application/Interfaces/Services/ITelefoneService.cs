using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface ITelefoneService
    {
        Task UpdateTelefone(Telefone telefone);
        Task InativaTelefone(int id);
    }
}