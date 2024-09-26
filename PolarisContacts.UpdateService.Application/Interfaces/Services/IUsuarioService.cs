using System.Threading.Tasks;

namespace PolarisContacts.UpdateService.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task ValidaChangeUserPassword(string login, string oldPassword, string newPassword);
    }
}