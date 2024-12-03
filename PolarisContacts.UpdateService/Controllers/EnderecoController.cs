using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolarisContacts.UpdateService.Application.Interfaces.Messaging;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using PolarisContacts.UpdateService.Domain.Enuns;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("Update/[controller]")]
    public class EnderecoController(ILogger<EnderecoController> logger, IEnderecoService enderecoService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger = logger;
        private readonly IEnderecoService _enderecoService = enderecoService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPut("UpdateEndereco")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult UpdateEndereco(Endereco endereco)
        {
            try
            {
                _enderecoService.ValidaEndereco(endereco);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Update,
                    EntityType = EntityType.Endereco,
                    EntityData = endereco
                };

                // Serializa o objeto contato para JSON
                var message = JsonConvert.SerializeObject(entityMessage);

                // Publica a mensagem no RabbitMQ
                _rabbitMqProducer.Publish(message);

                return Ok("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                return StatusCode(500, $"Erro ao publicar mensagem: {ex.Message}");
            }
        }

        [HttpPut("InativaEndereco/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InativaEndereco(int id)
        {
            try
            {
                _enderecoService.ValidaInativarEndereco(id);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Inactivate,
                    EntityType = EntityType.Endereco,
                    EntityData = new Endereco { Id = id }
                };

                // Serializa o objeto contato para JSON
                var message = JsonConvert.SerializeObject(entityMessage);

                // Publica a mensagem no RabbitMQ
                _rabbitMqProducer.Publish(message);

                return Ok("Mensagem publicada com sucesso.");
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                return StatusCode(500, $"Erro ao publicar mensagem: {ex.Message}");
            }
        }
    }
}
