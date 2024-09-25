using Microsoft.AspNetCore.Mvc;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;

namespace PolarisContacts.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController(ILogger<EmailController> logger, IEmailService emailService) : ControllerBase
    {
        private readonly ILogger<EmailController> _logger = logger;
        private readonly IEmailService _emailService = emailService;

        [HttpPut("UpdateEmail")]
        public bool UpdateEmail(Email email)
        {
            try
            {
                _emailService.UpdateEmail(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        [HttpPut("InativaEmail/{id}")]
        public bool InativaEmail(int id)
        {
            try
            {
                _emailService.InativaEmail(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
