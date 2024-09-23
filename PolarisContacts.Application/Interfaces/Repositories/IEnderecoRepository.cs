using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<bool> UpdateEndereco(Endereco endereco);
        Task<bool> DeleteEndereco(int id);
    }
}