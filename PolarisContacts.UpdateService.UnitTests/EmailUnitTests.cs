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
    public class EmailUnitTests
    {
        private readonly EmailService _emailService;

        public EmailUnitTests()
        {
            _emailService = new EmailService();
        }

        [Fact]
        public void ValidaEmail_DeveExecutarSemErros_QuandoEmailEhValido()
        {
            // Arrange
            var email = new Email
            {
                Id = 1,
                EnderecoEmail = "teste@example.com" // E-mail válido
            };

            var emailService = new EmailService();

            // Act & Assert
            var exception = Record.Exception(() => emailService.ValidaEmail(email));

            Assert.Null(exception); // Verifica que não houve exceção
        }

        [Fact]
        public void ValidaEmail_DeveLancarArgumentNullException_QuandoEmailEhNulo()
        {
            // Arrange
            Email email = null;
            var emailService = new EmailService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => emailService.ValidaEmail(email));
        }

        [Fact]
        public void ValidaEmail_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            var email = new Email
            {
                Id = 0, // ID inválido
                EnderecoEmail = "teste@example.com"
            };

            var emailService = new EmailService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => emailService.ValidaEmail(email));
        }

        [Fact]
        public void ValidaEmail_DeveLancarEmailInvalidoException_QuandoEmailEhInvalido()
        {
            // Arrange
            var email = new Email
            {
                Id = 1,
                EnderecoEmail = "testecom" // E-mail inválido
            };

            var emailService = new EmailService();

            // Act & Assert
            Assert.Throws<EmailInvalidoException>(() => emailService.ValidaEmail(email));
        }

        [Fact]
        public void ValidaInativarEmail_DeveExecutarSemErros_QuandoIdEhValido()
        {
            // Arrange
            int emailId = 1; // ID válido
            var emailService = new EmailService();

            // Act & Assert
            var exception = Record.Exception(() => emailService.ValidaInativarEmail(emailId));

            Assert.Null(exception); // Verifica que não houve exceção
        }

        [Fact]
        public void ValidaInativarEmail_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            int emailId = 0; // ID inválido
            var emailService = new EmailService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => emailService.ValidaInativarEmail(emailId));
        }


    }
}
