using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using System.Threading.Tasks;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task ValidaChangeUserPassword(string login, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new LoginVazioException();
            }
            if (string.IsNullOrEmpty(oldPassword))
            {
                throw new SenhaIncorretaException();
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new SenhaVaziaException();
            }

            if (await _usuarioRepository.GetUserByPasswordAsync(login, oldPassword) is null)
            {
                throw new SenhaIncorretaException();
            }
        }
    }
}

