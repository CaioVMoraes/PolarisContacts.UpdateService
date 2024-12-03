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
    public class TelefoneController(ILogger<TelefoneController> logger, ITelefoneService telefoneService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<TelefoneController> _logger = logger;
        private readonly ITelefoneService _telefoneService = telefoneService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPut("UpdateTelefone")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult UpdateTelefone(Telefone telefone)
        {
            try
            {
                _telefoneService.ValidaTelefone(telefone);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Update,
                    EntityType = EntityType.Telefone,
                    EntityData = telefone
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

        [HttpPut("InativaTelefone/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InativaTelefone(int id)
        {
            try
            {
                _telefoneService.ValidaInativarTelefone(id);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Inactivate,
                    EntityType = EntityType.Telefone,
                    EntityData = new Telefone { Id = id }
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
