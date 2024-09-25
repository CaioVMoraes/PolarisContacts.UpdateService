using Dapper;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Infrastructure.Repositories
{
    public class TelefoneRepository(IDatabaseConnection dbConnection) : ITelefoneRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> UpdateTelefone(Telefone telefone)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Telefones SET 
                             IdRegiao = @IdRegiao, NumeroTelefone = @NumeroTelefone
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, telefone) > 0;
        }

        public async Task<bool> InativaTelefone(int id)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Telefones SET 
                             Ativo = 0
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, new { Id = id }) > 0;
        }
    }
}