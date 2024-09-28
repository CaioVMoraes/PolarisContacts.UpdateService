using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

namespace PolarisContacts.UpdateService.IntegrationTests
{
    public class CelularControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public CelularControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task UpdateCelular_ReturnsSuccess()
        {
            var celular = new Celular
            {
                Id = 1,
                IdRegiao = 1,
                NumeroCelular = "98765-4321",
                Ativo = true
            };

            // Faz a requisição para atualizar o contato
            var content = new StringContent(JsonConvert.SerializeObject(celular), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("Celular/UpdateCelular", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }


        [Fact]
        public async Task InativaCelular_ReturnsSuccess()
        {
            // ID do contato
            var celularId = 1;
            var requestUri = $"Celular/InativaCelular/{celularId}";

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