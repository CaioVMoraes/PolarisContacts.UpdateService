using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class TelefoneService(ITelefoneRepository telefoneRepository) : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository = telefoneRepository;

        public async Task UpdateTelefone(Telefone telefone)
        {
            if (telefone == null || telefone.Id <= 0)
            {
                throw new ArgumentNullException(nameof(telefone));
            }

            await _telefoneRepository.UpdateTelefone(telefone);
        }

        public async Task InativaTelefone(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            await _telefoneRepository.InativaTelefone(id);
        }
    }
}