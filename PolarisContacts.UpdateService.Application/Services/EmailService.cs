using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Domain;
using PolarisContacts.UpdateService.Helpers;
using System;
using static PolarisContacts.UpdateService.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class EmailService : IEmailService
    {
        public void ValidaEmail(Email email)
        {
            if (email == null || email.Id <= 0)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (!Validacoes.IsValidEmail(email.EnderecoEmail))
            {
                throw new EmailInvalidoException();
            }
        }

        public void ValidaInativarEmail(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
        }
    }
}