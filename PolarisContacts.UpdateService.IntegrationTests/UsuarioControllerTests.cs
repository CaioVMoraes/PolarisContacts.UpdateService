
using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

namespace PolarisContacts.UpdateService.IntegrationTests
{
    public class UsuarioControllerTests : IClassFixture<IntegrationTestFixture>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFixture _fixture;

        public UsuarioControllerTests(IntegrationTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.Client;
        }

        [Fact]
        public async Task ChangePassword_ReturnSuccess()
        {
            // Define os dados de teste
            var usuario = new Usuario
            {
                Login = "Login Teste",
                Senha = "102030",
                NovaSenha = "123456",
                Ativo = true
            };            

            // Serializa o objeto Usuario para JSON
            var jsonContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            // Faz a requisição para criar o usuário via POST
            var response = await _client.PutAsync("Update/Usuario/ChangeUserPasswordAsync", jsonContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }      
    }
}