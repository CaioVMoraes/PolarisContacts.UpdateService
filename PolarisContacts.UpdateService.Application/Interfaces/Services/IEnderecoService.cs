using PolarisContacts.UpdateService.Domain;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IEnderecoService
    {
        void ValidaEndereco(Endereco endereco);
        void ValidaInativarEndereco(int id);
    }
}