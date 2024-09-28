using NSubstitute;
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
    public class CelularUnitTests
    {
        private readonly CelularService _celularService;

        public CelularUnitTests()
        {
            _celularService = new CelularService();
        }

        [Fact]
        public void ValidaCelular_DeveExecutarSemErros_QuandoCelularEhValido()
        {
            // Arrange
            var celular = new Celular
            {
                Id = 1,
                NumeroCelular = "12345-6789" 
            };

            var celularService = new CelularService();

            // Act & Assert
            var exception = Record.Exception(() => celularService.ValidaCelular(celular));

            Assert.Null(exception); 
        }

        [Fact]
        public void ValidaCelular_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            var celular = new Celular
            {
                Id = 0, 
                NumeroCelular = "12345-6789"
            };

            var celularService = new CelularService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => celularService.ValidaCelular(celular));
        }

        [Fact]
        public void ValidaCelular_DeveLancarCelularInvalidoException_QuandoNumeroCelularEhInvalido()
        {
            // Arrange
            var celular = new Celular
            {
                Id = 1,
                NumeroCelular = "123456789" 
            };

            var celularService = new CelularService();

            // Act & Assert
            Assert.Throws<CelularInvalidoException>(() => celularService.ValidaCelular(celular));
        }

        [Fact]
        public void ValidaInativarCelular_DeveExecutarSemErros_QuandoIdEhValido()
        {
            // Arrange
            int celularId = 1; 
            var celularService = new CelularService();

            // Act & Assert
            var exception = Record.Exception(() => celularService.ValidaInativarCelular(celularId));

            Assert.Null(exception); 
        }

        [Fact]
        public void ValidaInativarCelular_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            int celularId = 0; 
            var celularService = new CelularService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => celularService.ValidaInativarCelular(celularId));
        }

    }
}
