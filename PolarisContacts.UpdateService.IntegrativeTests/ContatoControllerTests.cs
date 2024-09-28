using Newtonsoft.Json;
using PolarisContacts.UpdateService.Domain;
using System.Text;

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
    public async Task InativaContato_ReturnsSuccess()
    {
        // ID do contato a ser inativado
        var contatoId = 1;

        // Formata a URL da requisição de acordo com a rota da controller
        var requestUri = $"Contato/InativaContato/{contatoId}";

        // Cria uma requisição PUT
        var request = new HttpRequestMessage(HttpMethod.Put, requestUri);

        // Envia a requisição
        var response = await _client.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Verifica se a resposta é bem-sucedida
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal("Contato deletado com sucesso.", responseContent);
    }


}
