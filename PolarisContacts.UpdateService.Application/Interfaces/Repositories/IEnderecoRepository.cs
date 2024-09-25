using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<bool> UpdateEndereco(Endereco endereco);
        Task<bool> InativaEndereco(int id);
    }
}