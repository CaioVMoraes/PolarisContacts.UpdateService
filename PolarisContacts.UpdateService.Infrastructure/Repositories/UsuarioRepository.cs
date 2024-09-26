using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<Usuario> GetUserByPasswordAsync(string login, string senha)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:7048/Usuario/GetUserByPasswordAsync?login={login}&senha={senha}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            else
            {
                throw new HttpRequestException($"Erro ao obter usuário: {response.StatusCode}");
            }
        }
    }
}
