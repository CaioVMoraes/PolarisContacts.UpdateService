using PolarisContacts.Domain;
using System.Threading.Tasks;

namespace PolarisContacts.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> ChangeUserPasswordAsync(string login, string oldPassword, string newPassword);
    }
}