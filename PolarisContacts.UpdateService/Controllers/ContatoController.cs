using Microsoft.AspNetCore.Mvc;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController(ILogger<ContatoController> logger, IContatoService contatoService) : ControllerBase
    {
        private readonly ILogger<ContatoController> _logger = logger;
        private readonly IContatoService _contatoService = contatoService;

        [HttpPut("UpdateContato")]
        public bool UpdateContato(Contato contato)
        {
            try
            {
                _contatoService.UpdateContato(contato);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        [HttpPut("InativaContato/{id}")]
        public bool InativaContato(int id)
        {
            try
            {
                _contatoService.InativaContato(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
