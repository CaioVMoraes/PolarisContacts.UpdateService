using Microsoft.AspNetCore.Mvc;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController(ILogger<TelefoneController> logger, ITelefoneService telefoneService) : ControllerBase
    {
        private readonly ILogger<TelefoneController> _logger = logger;
        private readonly ITelefoneService _telefoneService = telefoneService;

        [HttpPut("UpdateTelefone")]
        public bool UpdateTelefone(Telefone telefone)
        {
            try
            {
                _telefoneService.UpdateTelefone(telefone);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        [HttpPut("InativaTelefone/{id}")]
        public bool InativaTelefone(int id)
        {
            try
            {
                _telefoneService.InativaTelefone(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
