using NSubstitute;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Services;
using PolarisContacts.UpdateService.Domain;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.UnitTests
{
    public class UsuarioUnitTests
    {
        private readonly IUsuarioRepository _usuarioRepository = Substitute.For<IUsuarioRepository>();
        private readonly UsuarioService _usuarioService;

        public UsuarioUnitTests()
        {
            _usuarioService = new UsuarioService(_usuarioRepository);
        }        

        [Fact]
        public async Task ValidaChangeUserPassword_DeveLancarSenhaIncorretaException_QuandoLoginEhNuloOuVazio()
        {
            // Arrange
            string login = "Admin";
            string oldPassword = null;
            string newPassword = "NewTestPassword";

            // Act & Assert
            await Assert.ThrowsAsync<SenhaIncorretaException>(() => _usuarioService.ValidaChangeUserPassword(login, oldPassword, newPassword));
        }

        [Fact]
        public async Task ValidaChangeUserPassword_DeveLancarSenhaVaziaException_QuandoLoginEhNuloOuVazio()
        {
            // Arrange
            string login = "Admin";
            string oldPassword = "TestPassword";
            string newPassword = null;

            // Act & Assert
            await Assert.ThrowsAsync<SenhaVaziaException>(() => _usuarioService.ValidaChangeUserPassword(login, oldPassword, newPassword));
        }

        [Fact]
        public async Task ValidaChangeUserPassword_DeveLancarSenhaIncorretaException_QuandoUsuarioOuSenhaIncorreto()
        {
            // Arrange
            string login = "existingUser";
            string oldPassword = "oldPassword";
            string newPassword = "newPassword";
            _usuarioRepository.GetUserByPasswordAsync(login, oldPassword).Returns(Task.FromResult<Usuario>(null));

            // Act & Assert
            await Assert.ThrowsAsync<SenhaIncorretaException>(() => _usuarioService.ValidaChangeUserPassword(login, oldPassword, newPassword));
        }
    }
}