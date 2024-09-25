using Microsoft.AspNetCore.Mvc;
using PolarisContacts.UpdateService.Application.Interfaces.Services;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService) : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger = logger;
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpPut("ChangeUserPasswordAsync")]
        public bool ChangeUserPasswordAsync(string login, string oldPassword, string newPassword)
        {
            try
            {
                _usuarioService.ChangeUserPasswordAsync(login, oldPassword, newPassword);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
