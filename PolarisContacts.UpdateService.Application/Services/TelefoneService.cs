using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using PolarisContacts.UpdateService.Helpers;
using System;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class TelefoneService : ITelefoneService
    {
        public void ValidaTelefone(Telefone telefone)
        {
            if (telefone == null || telefone.Id <= 0)
            {
                throw new ArgumentNullException(nameof(telefone));
            }

            if (!Validacoes.IsValidTelefone(telefone.NumeroTelefone))
            {
                throw new TelefoneInvalidoException();
            }
        }

        public void ValidaInativarTelefone(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
        }
    }
}