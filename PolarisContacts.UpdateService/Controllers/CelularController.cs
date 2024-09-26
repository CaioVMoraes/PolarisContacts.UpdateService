using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolarisContacts.UpdateService.Application.Interfaces.Messaging;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using PolarisContacts.UpdateService.Domain.Enuns;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelularController(ILogger<CelularController> logger, ICelularService celularService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<CelularController> _logger = logger;
        private readonly ICelularService _celularService = celularService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPut("UpdateCelular")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult UpdateCelular(Celular celular)
        {
            try
            {
                _celularService.ValidaCelular(celular);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Update,
                    EntityType = EntityType.Celular,
                    EntityData = celular
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

        [HttpPut("InativaCelular/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InativaCelular(int id)
        {
            try
            {
                _celularService.ValidaInativarCelular(id);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Inactivate,
                    EntityType = EntityType.Celular,
                    EntityData = new Celular { Id = id }
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
