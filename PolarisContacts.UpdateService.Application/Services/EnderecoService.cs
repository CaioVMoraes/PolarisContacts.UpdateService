using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class EnderecoService(IEnderecoRepository enderecoRepository) : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;

        public async Task UpdateEndereco(Endereco endereco)
        {
            if (endereco == null || endereco.Id <= 0)
            {
                throw new ArgumentNullException(nameof(endereco));
            }

            await _enderecoRepository.UpdateEndereco(endereco);
        }

        public async Task InativaEndereco(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            await _enderecoRepository.InativaEndereco(id);
        }
    }
}