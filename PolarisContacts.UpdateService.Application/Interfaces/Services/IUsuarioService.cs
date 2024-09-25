using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> ChangeUserPasswordAsync(string login, string oldPassword, string newPassword);
    }
}