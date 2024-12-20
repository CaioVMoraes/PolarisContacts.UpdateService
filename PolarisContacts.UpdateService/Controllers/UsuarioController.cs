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
    public class UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService, IRabbitMqProducer rabbitMqProducer) : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger = logger;
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly IRabbitMqProducer _rabbitMqProducer = rabbitMqProducer;

        [HttpPut("ChangeUserPasswordAsync")]
        public IActionResult ChangeUserPasswordAsync(Usuario usuario)
        {
            try
            {
                _usuarioService.ValidaChangeUserPassword(usuario.Login, usuario.Senha, usuario.NovaSenha);

                var entityMessage = new EntityMessage
                {
                    Operation = OperationType.Update,
                    EntityType = EntityType.Usuario,
                    EntityData = usuario
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

        [HttpGet]
        public string Get()
        {
            return "sucesso";
        }
    }
}
