using Dapper;
using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Domain;
using System.Data;
using System.Threading.Tasks;

namespace PolarisContacts.Infrastructure.Repositories
{
    public class UsuarioRepository(IDatabaseConnection dbConnection) : IUsuarioRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> ChangeUserPasswordAsync(string login, string oldPassword, string newPassword)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = "UPDATE Usuarios SET Senha = @NewPassword WHERE [Login] = @Login AND Senha = @OldPassword AND Ativo = 1";

            return await conn.ExecuteAsync(query, new { Login = login, OldPassword = oldPassword, NewPassword = newPassword }) > 0;
        }
    }
}
