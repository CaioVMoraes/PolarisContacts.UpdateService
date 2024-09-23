using PolarisContacts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface IEnderecoService
    {
        Task UpdateEndereco(Endereco endereco);
        Task DeleteEndereco(int id);
    }
}