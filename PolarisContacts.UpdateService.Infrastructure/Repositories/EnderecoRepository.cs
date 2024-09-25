using Dapper;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Infrastructure.Repositories
{
    public class EnderecoRepository(IDatabaseConnection dbConnection) : IEnderecoRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> UpdateEndereco(Endereco endereco)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Enderecos SET 
                                Logradouro = @Logradouro, Numero = @Numero, Cidade = @Cidade, Estado = @Estado, 
                                Bairro = @Bairro, Complemento = @Complemento, CEP = @CEP 
                                WHERE Id = @Id";

            return await conn.ExecuteAsync(query, endereco) > 0;

        }

        public async Task<bool> InativaEndereco(int id)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"UPDATE Enderecos SET 
                             Ativo = 0
                             WHERE Id = @Id";

            return await conn.ExecuteAsync(query, new { Id = id }) > 0;

        }
    }
}
