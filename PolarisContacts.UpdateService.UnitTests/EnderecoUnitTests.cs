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
    public class EnderecoUnitTests
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoUnitTests()
        {
            _enderecoService = new EnderecoService();
        }

        [Fact]
        public void ValidaEndereco_DeveExecutarSemErros_QuandoEnderecoEhValido()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = 1,
                Logradouro = "Rua dos Testes",
                Numero = "100",
                Cidade = "São Paulo",
                Estado = "SP",
                Bairro = "Centro",
                CEP = "01000-000",
                Ativo = true
            };

            var enderecoService = new EnderecoService();

            // Act & Assert
            var exception = Record.Exception(() => enderecoService.ValidaEndereco(endereco));

            Assert.Null(exception); // Verifica que não houve exceção
        }

        [Fact]
        public void ValidaEndereco_DeveLancarArgumentNullException_QuandoEnderecoEhNulo()
        {
            // Arrange
            Endereco endereco = null;
            var enderecoService = new EnderecoService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => enderecoService.ValidaEndereco(endereco));
        }

        [Fact]
        public void ValidaEndereco_DeveLancarArgumentNullException_QuandoIdEhInvalido()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = 0, // ID inválido
                Logradouro = "Rua dos Testes",
                Numero = "100",
                Cidade = "São Paulo",
                Estado = "SP",
                Bairro = "Centro",
                CEP = "01000-000",
                Ativo = true
            };

            var enderecoService = new EnderecoService();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => enderecoService.ValidaEndereco(endereco));
        }

        [Fact]
        public void ValidaEndereco_DeveLancarEnderecoInvalidoException_QuandoEnderecoEhInvalido()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = 1,
                Logradouro = "", // Logradouro inválido
                Numero = "100",
                Cidade = "São Paulo",
                Estado = "SP",
                Bairro = "Centro",
                CEP = "01000-000",
                Ativo = true
            };

            var enderecoService = new EnderecoService();

            // Act & Assert
            Assert.Throws<EnderecoInvalidoException>(() => enderecoService.ValidaEndereco(endereco));
        }

        [Fact]
        public void ValidaInativarEndereco_DeveExecutarSemErros_QuandoIdEhValido()
        {
            // Arrange
            int enderecoId = 1; // ID válido
            var enderecoService = new EnderecoService();

            // Act & Assert
            var exception = Record.Exception(() => enderecoService.ValidaInativarEndereco(enderecoId));

            Assert.Null(exception); // Verifica que não houve exceção
        }

        [Fact]
        public void ValidaInativarEndereco_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            int enderecoId = 0; // ID inválido
            var enderecoService = new EnderecoService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => enderecoService.ValidaInativarEndereco(enderecoId));
        }

    }
}
