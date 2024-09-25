using Microsoft.AspNetCore.Mvc;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelularController(ILogger<CelularController> logger, ICelularService celularService) : ControllerBase
    {
        private readonly ILogger<CelularController> _logger = logger;
        private readonly ICelularService _celularService = celularService;

        [HttpPut("UpdateCelular")]
        public bool UpdateCelular(Celular celular)
        {
            try
            {
                _celularService.UpdateCelular(celular);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        [HttpPut("InativaCelular/{id}")]
        public bool InativaCelular(int id)
        {
            try
            {
                _celularService.InativaCelular(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
