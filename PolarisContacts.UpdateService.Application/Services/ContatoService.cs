using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class ContatoService : IContatoService
    {
        public void ValidaContato(Contato contato)
        {
            if (contato.Id <= 0)
            {
                throw new InvalidIdException();
            }
            if (string.IsNullOrEmpty(contato.Nome))
            {
                throw new NomeObrigatorioException();
            }
        }

        public void ValidaInativarContato(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
        }
    }
}