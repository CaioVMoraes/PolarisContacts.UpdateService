using Microsoft.AspNetCore.Mvc;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController(ILogger<EnderecoController> logger, IEnderecoService enderecoService) : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger = logger;
        private readonly IEnderecoService _enderecoService = enderecoService;

        [HttpPut("UpdateEndereco")]
        public bool UpdateEndereco(Endereco endereco)
        {
            try
            {
                _enderecoService.UpdateEndereco(endereco);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        [HttpPut("InativaEndereco/{id}")]
        public bool InativaEndereco(int id)
        {
            try
            {
                _enderecoService.InativaEndereco(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
