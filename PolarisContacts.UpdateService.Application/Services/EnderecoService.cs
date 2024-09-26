using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using PolarisContacts.UpdateService.Helpers;
using System;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        public void ValidaEndereco(Endereco endereco)
        {
            if (endereco == null || endereco.Id <= 0)
            {
                throw new ArgumentNullException(nameof(endereco));
            }

            if (!Validacoes.IsValidEndereco(endereco))
            {
                throw new EnderecoInvalidoException();
            }
        }

        public void ValidaInativarEndereco(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
        }
    }
}