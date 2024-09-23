﻿using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.Domain;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<bool> ChangeUserPasswordAsync(string login, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new LoginVazioException();
            }
            if (string.IsNullOrEmpty(oldPassword))
            {
                throw new SenhaIncorretaException();
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                throw new SenhaVaziaException();
            }

            //if (await _usuarioRepository.GetUserByPasswordAsync(login, oldPassword) is null)
            //{
            //    throw new SenhaIncorretaException();
            //}

            return await _usuarioRepository.ChangeUserPasswordAsync(login, oldPassword, newPassword);
        }
    }
}

