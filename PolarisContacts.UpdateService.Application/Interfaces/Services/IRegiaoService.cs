using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IRegiaoService
    {
        Task<IEnumerable<Regiao>> GetAll();
        Task<Regiao> GetById(int idRegiao);
    }
}