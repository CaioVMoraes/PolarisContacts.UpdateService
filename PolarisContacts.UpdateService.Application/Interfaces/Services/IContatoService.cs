using PolarisContacts.UpdateService.Domain;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IContatoService
    {
        void ValidaContato(Contato contato);
        void ValidaInativarContato(int id);
    }
}