using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using PolarisContacts.UpdateService.Helpers;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class CelularService : ICelularService
    {
        public void ValidaCelular(Celular celular)
        {
            if (celular.Id <= 0)
            {
                throw new InvalidIdException();
            }

            if (!Validacoes.IsValidCelular(celular.NumeroCelular))
            {
                throw new CelularInvalidoException();
            }
        }

        public void ValidaInativarCelular(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
        }
    }
}