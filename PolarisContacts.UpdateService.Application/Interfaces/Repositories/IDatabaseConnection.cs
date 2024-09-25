using System.Data;

namespace PolarisContacts.UpdateService.Application.Interfaces.Repositories
{
    public interface IDatabaseConnection
    {
        IDbConnection AbrirConexao();
    }
}
