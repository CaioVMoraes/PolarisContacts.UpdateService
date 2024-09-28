using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

namespace PolarisContacts.UpdateService.IntegrationTests
{
    public class EnderecoControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public EnderecoControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task UpdateEndereco_ReturnsSuccess()
        {
            var endereco = new Endereco
            {
                Id = 1,
                IdContato = 1,
                Logradouro = "Rua dos Cabiros",
                Numero = "36",
                Cidade = "São Paulo",
                Estado = "SP",
                Bairro = "Jardim Itajaí",
                Complemento = "CASA",
                CEP = "04855-140",
                Ativo = true
            };

            // Faz a requisição para atualizar o contato
            var content = new StringContent(JsonConvert.SerializeObject(endereco), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("Endereco/UpdateEndereco", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }


        [Fact]
        public async Task InativaEndereco_ReturnsSuccess()
        {
            // ID do contato
            var enderecoId = 1;
            var requestUri = $"Endereco/InativaEndereco/{enderecoId}";

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