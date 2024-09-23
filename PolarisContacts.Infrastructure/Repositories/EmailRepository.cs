using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
{
    public class EmailRepository(IDatabaseConnection dbConnection) : IEmailRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;


        public async Task<bool> UpdateEmail(Email email)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Emails SET 
                             EnderecoEmail = @EnderecoEmail
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, email) > 0;
        }

        public async Task<bool> DeleteEmail(int id)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Emails SET 
                             Ativo = 0
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, new { Id = id }) > 0;
        }
    }
}
