using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> ChangeUserPasswordAsync(string login, string oldPassword, string newPassword);
    }
}