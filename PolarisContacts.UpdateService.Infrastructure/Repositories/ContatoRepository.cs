using Dapper;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Infrastructure.Repositories
{
    public class ContatoRepository(IDatabaseConnection dbConnection) : IContatoRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> UpdateContato(Contato contato)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Contatos SET 
                             Nome = @Nome, Ativo = @Ativo 
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, contato) > 0;
        }

        public async Task<bool> InativaContato(int idContato)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Contatos SET 
                             Ativo = 0
                             WHERE Id = @Id";
            return await conn.ExecuteAsync(query, new { Id = idContato }) > 0;
        }
    }
}