using Dapper;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Infrastructure.Repositories
{
    public class CelularRepository(IDatabaseConnection dbConnection) : ICelularRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<Celular> GetCelularById(int id)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync($"https://localhost:7048/Celular/GetCelularById/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Celular>();
            }
            else
            {
                throw new HttpRequestException($"Erro ao obter celular: {response.StatusCode}");
            }
        }

        public async Task<bool> UpdateCelular(Celular celular)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Celulares SET 
                             IdRegiao = @IdRegiao, NumeroCelular = @NumeroCelular
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, celular) > 0;
        }

        public async Task<bool> InativaCelular(int id)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Celulares SET 
                             Ativo = 0
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, new { Id = id }) > 0;
        }
    }
}
