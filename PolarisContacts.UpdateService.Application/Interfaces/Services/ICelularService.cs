using PolarisContacts.UpdateService.Domain;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface ICelularService
    {
        void ValidaCelular(Celular celular);
        void ValidaInativarCelular(int id);
    }
}
