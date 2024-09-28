
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
            string login = "Login Teste";
            string oldPassword = "1";
            string newPassword = "newPassword";

            // Cria a URL com os parâmetros na query string
            var requestUrl = $"Usuario/ChangeUserPasswordAsync?login={login}&oldPassword={oldPassword}&newPassword={newPassword}";

            var response = await _client.PutAsync(requestUrl, null);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Verifica se a resposta é bem-sucedida
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal("Mensagem publicada com sucesso.", responseContent);
        }
    }
}