using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

namespace PolarisContacts.UpdateService.IntegrationTests
{
    public class ContatoControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public ContatoControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task UpdateContato_ReturnsSuccess()
        {
            var contato = new Contato
            {
                Id = 1,
                Nome = "Contato Atualizado",
                IdUsuario = 2,
                Ativo = true,
                Celulares = new List<Celular>
        {
            new Celular
            {
                Id = 1,
                IdRegiao = 1,
                NumeroCelular = "98765-4321",
                Ativo = true
            }
        },
                Enderecos = new List<Endereco>
        {
            new Endereco
            {
                Id = 1,
                Logradouro = "Avenida Paulista",
                Numero = "1000",
                Cidade = "São Paulo",
                Estado = "SP",
                Bairro = "Centro",
                Complemento = "Apto 200",
                CEP = "01310-100",
                Ativo = true
            }
        },
                Telefones = new List<Telefone>
        {
            new Telefone
            {
                Id = 1,
                IdRegiao = 1,
                NumeroTelefone = "1234-5678",
                Ativo = true
            }
        },
                Emails = new List<Email>
        {
            new Email
            {
                Id = 1,
                EnderecoEmail = "contatoatualizado@teste.com",
                Ativo = true
            }
        }
            };

            // Faz a requisição para atualizar o contato
            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("Update/Contato/UpdateContato", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }


        [Fact]
        public async Task InativaContato_ReturnsSuccess()
        {
            // ID do contato
            var contatoId = 1;
            var requestUri = $"Update/Contato/InativaContato/{contatoId}";

            // Envia a requisição
            var request = new HttpRequestMessage(HttpMethod.Put, requestUri);
            var response = await _client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }


    }
}