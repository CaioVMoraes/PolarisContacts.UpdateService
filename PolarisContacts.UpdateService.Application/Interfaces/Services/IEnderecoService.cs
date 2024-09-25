using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IEnderecoService
    {
        Task UpdateEndereco(Endereco endereco);
        Task InativaEndereco(int id);
    }
}