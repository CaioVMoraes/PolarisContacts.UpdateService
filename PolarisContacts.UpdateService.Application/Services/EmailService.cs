using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.UpdateService.Application.Services
{
    public class EmailService(IEmailRepository emailRepository) : IEmailService
    {
        private readonly IEmailRepository _emailRepository = emailRepository;

        public async Task UpdateEmail(Email email)
        {
            if (email == null || email.Id <= 0)
            {
                throw new ArgumentNullException(nameof(email));
            }

            await _emailRepository.UpdateEmail(email);
        }

        public async Task InativaEmail(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            await _emailRepository.InativaEmail(id);
        }
    }
}