using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

namespace PolarisContacts.UpdateService.IntegrativeTests
{
    public class EmailControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public EmailControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task UpdateEmail_ReturnsSuccess()
        {
            var email = new Email
            {
                Id = 1,
                IdContato = 1,
                EnderecoEmail = "JhonatanPsilva@teste.com.br",
                Ativo = true
            };

            // Faz a requisição para atualizar o contato
            var content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("Email/UpdateEmail", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }


        [Fact]
        public async Task InativaEmail_ReturnsSuccess()
        {
            // ID do contato
            var emailId = 1;
            var requestUri = $"Email/InativaEmail/{emailId}";

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