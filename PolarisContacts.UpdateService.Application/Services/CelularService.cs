using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class CelularService(ICelularRepository celularRepository) : ICelularService
    {
        private readonly ICelularRepository _celularRepository = celularRepository;

        public async Task UpdateCelular(Celular celular)
        {
            if (celular == null || celular.Id <= 0)
            {
                throw new ArgumentNullException(nameof(celular));
            }

            await _celularRepository.UpdateCelular(celular);
        }

        public async Task InativaCelular(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var existingCelular = await _celularRepository.GetCelularById(id);

            if (existingCelular == null)
            {
                throw new CelularNotFoundException();
            }

            await _celularRepository.InativaCelular(id);
        }
    }
}