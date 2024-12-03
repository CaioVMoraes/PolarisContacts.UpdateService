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
    public class EmailController(ILogger<EmailController> logger, IEmailService emailService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<EmailController> _logger = logger;
        private readonly IEmailService _emailService = emailService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPut("UpdateEmail")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult UpdateEmail(Email email)
        {
            try
            {
                _emailService.ValidaEmail(email);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Update,
                    EntityType = EntityType.Email,
                    EntityData = email
                };

                // Serializa o objeto email para JSON
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

        [HttpPut("InativaEmail/{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult InativaEmail(int id)
        {
            try
            {
                _emailService.ValidaInativarEmail(id);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Inactivate,
                    EntityType = EntityType.Email,
                    EntityData = new Email { Id = id }
                };

                // Serializa o objeto email para JSON
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
