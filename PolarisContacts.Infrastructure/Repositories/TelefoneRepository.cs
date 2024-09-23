using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
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

        public async Task<bool> DeleteTelefone(int id)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Telefones SET 
                             Ativo = 0
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, new { Id = id }) > 0;
        }
    }
}