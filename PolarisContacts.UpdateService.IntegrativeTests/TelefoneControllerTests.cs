using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

namespace PolarisContacts.UpdateService.IntegrativeTests
{
    public class TelefoneControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public TelefoneControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task UpdateTelefone_ReturnsSuccess()
        {
            var telefone = new Telefone
            {
                Id = 1,
                IdRegiao = 1,
                IdContato = 1,
                NumeroTelefone = "5526-9799",
                Ativo = true
            };

            // Faz a requisição para atualizar o contato
            var content = new StringContent(JsonConvert.SerializeObject(telefone), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("Telefone/UpdateTelefone", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }


        [Fact]
        public async Task InativaTelefone_ReturnsSuccess()
        {
            // ID do contato
            var telefoneId = 1;
            var requestUri = $"Telefone/InativaTelefone/{telefoneId}";

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