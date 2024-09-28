using PolarisContacts.UpdateService.Application.Services;
using PolarisContacts.UpdateService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.UnitTests
{
    public class TelefoneUnitTests
    {
        private readonly TelefoneService _telefoneService;

        public TelefoneUnitTests()
        {
            _telefoneService = new TelefoneService();
        }

        [Fact]
        public void ValidaTelefone_DeveExecutarSemErros_QuandoTelefoneEhValido()
        {
            // Arrange
            var telefone = new Telefone
            {
                Id = 1,
                NumeroTelefone = "2345-6789" // Telefone válido
            };

            var telefoneService = new TelefoneService();

            // Act & Assert
            var exception = Record.Exception(() => telefoneService.ValidaTelefone(telefone));

            Assert.Null(exception); // Verifica que não houve exceção
        }


        [Fact]
        public void ValidaTelefone_DeveLancarArgumentNullException_QuandoTelefoneEhNulo()
        {
            // Arrange
            Telefone telefone = null;
            var telefoneService = new TelefoneService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => telefoneService.ValidaTelefone(telefone));
        }

        [Fact]
        public void ValidaTelefone_DeveLancarArgumentNullException_QuandoIdEhInvalido()
        {
            // Arrange
            var telefone = new Telefone
            {
                Id = 0, // ID inválido
                NumeroTelefone = "2345-6789"
            };

            var telefoneService = new TelefoneService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => telefoneService.ValidaTelefone(telefone));
        }


        [Fact]
        public void ValidaTelefone_DeveLancarTelefoneInvalidoException_QuandoTelefoneEhInvalido()
        {
            // Arrange
            var telefone = new Telefone
            {
                Id = 1,
                NumeroTelefone = "1234" // Telefone inválido
            };

            var telefoneService = new TelefoneService();

            // Act & Assert
            Assert.Throws<TelefoneInvalidoException>(() => telefoneService.ValidaTelefone(telefone));
        }

        [Fact]
        public void ValidaInativarTelefone_DeveExecutarSemErros_QuandoIdEhValido()
        {
            // Arrange
            int telefoneId = 1; // ID válido
            var telefoneService = new TelefoneService();

            // Act & Assert
            var exception = Record.Exception(() => telefoneService.ValidaInativarTelefone(telefoneId));

            Assert.Null(exception); // Verifica que não houve exceção
        }


        [Fact]
        public void ValidaInativarTelefone_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            int telefoneId = 0; // ID inválido
            var telefoneService = new TelefoneService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => telefoneService.ValidaInativarTelefone(telefoneId));
        }


    }
}
