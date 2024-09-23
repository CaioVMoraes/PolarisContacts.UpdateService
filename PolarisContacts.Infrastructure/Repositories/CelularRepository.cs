using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
{
    public class CelularRepository(IDatabaseConnection dbConnection) : ICelularRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> UpdateCelular(Celular celular)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Celulares SET 
                             IdRegiao = @IdRegiao, NumeroCelular = @NumeroCelular
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, celular) > 0;
        }

        public async Task<bool> DeleteCelular(int id)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Celulares SET 
                             Ativo = 0
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, new { Id = id }) > 0;
        }
    }
}
