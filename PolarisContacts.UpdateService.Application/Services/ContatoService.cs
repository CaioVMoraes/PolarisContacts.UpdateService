using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class ContatoService(IContatoRepository contatoRepository) : IContatoService
    {
        private readonly IContatoRepository _contatoRepository = contatoRepository;

        public async Task<bool> UpdateContato(Contato contato)
        {
            return await _contatoRepository.UpdateContato(contato);
        }

        public async Task<bool> InativaContato(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            return await _contatoRepository.InativaContato(id);
        }
    }
}