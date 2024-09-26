using PolarisContacts.UpdateService.Domain;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface ITelefoneService
    {
        void ValidaTelefone(Telefone telefone);
        void ValidaInativarTelefone(int id);
    }
}