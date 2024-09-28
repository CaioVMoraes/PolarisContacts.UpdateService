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
    public class ContatoUnitTests
    {
        private readonly ContatoService _contatoService;

        public ContatoUnitTests()
        {
            _contatoService = new ContatoService();
        }

        [Fact]
        public void ValidaContato_DeveExecutarSemErros_QuandoContatoEhValido()
        {
            // Arrange
            var contato = new Contato
            {
                Id = 1,
                Nome = "Contato Válido"
            };

            var contatoService = new ContatoService();

            // Act & Assert
            var exception = Record.Exception(() => contatoService.ValidaContato(contato));

            Assert.Null(exception); // Verifica se nenhuma exceção foi lançada
        }

        [Fact]
        public void ValidaContato_DeveLancarInvalidIdException_QuandoIdContatoEhInvalido()
        {
            // Arrange
            var contato = new Contato
            {
                Id = 0,  
                Nome = "Contato Inválido"
            };

            var contatoService = new ContatoService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => contatoService.ValidaContato(contato));
        }


        [Fact]
        public void ValidaContato_DeveLancarNomeObrigatorioException_QuandoNomeEhNuloOuVazio()
        {
            // Arrange
            var contato = new Contato
            {
                Id = 1,
                Nome = ""  // Nome vazio
            };

            var contatoService = new ContatoService();

            // Act & Assert
            Assert.Throws<NomeObrigatorioException>(() => contatoService.ValidaContato(contato));
        }


        [Fact]
        public void ValidaInativarContato_DeveExecutarSemErros_QuandoIdEhValido()
        {
            // Arrange
            int contatoId = 1;  // ID válido
            var contatoService = new ContatoService();

            // Act & Assert
            var exception = Record.Exception(() => contatoService.ValidaInativarContato(contatoId));

            Assert.Null(exception); // Verifica se nenhuma exceção foi lançada
        }

        [Fact]
        public void ValidaInativarContato_DeveLancarInvalidIdException_QuandoIdEhInvalido()
        {
            // Arrange
            int contatoId = 0;  
            var contatoService = new ContatoService();

            // Act & Assert
            Assert.Throws<InvalidIdException>(() => contatoService.ValidaInativarContato(contatoId));
        }



    }
}
