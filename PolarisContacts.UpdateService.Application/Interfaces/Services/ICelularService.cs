using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface ICelularService
    {
        Task UpdateCelular(Celular celular);
        Task InativaCelular(int id);
    }
}
