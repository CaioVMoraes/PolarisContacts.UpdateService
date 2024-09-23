using PolarisContacts.Application.Interfaces.Repositories;
using PolarisContacts.Application.Interfaces.Services;
using PolarisContacts.CrossCutting.Helpers;
using PolarisContacts.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static PolarisContacts.CrossCutting.Helpers.Exceptions.CustomExceptions;

namespace PolarisContacts.Application.Services
{
    public class ContatoService(IDatabaseConnection dbConnection,
                                IContatoRepository contatoRepository,
                                ITelefoneRepository telefoneRepository,
                                ICelularRepository celularRepository,
                                IEmailRepository emailRepository,
                                IEnderecoRepository enderecoRepository,
                                IRegiaoService regiaoService) : IContatoService
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;
        private readonly IContatoRepository _contatoRepository = contatoRepository;
        private readonly ITelefoneRepository _telefoneRepository = telefoneRepository;
        private readonly ICelularRepository _celularRepository = celularRepository;
        private readonly IEmailRepository _emailRepository = emailRepository;
        private readonly IEnderecoRepository _enderecoRepository = enderecoRepository;
        private readonly IRegiaoService _regiaoService = regiaoService;


        public async Task<bool> UpdateContato(Contato contato)
        {
            return await _contatoRepository.UpdateContato(contato);
        }

        public async Task<bool> DeleteContato(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            return await _contatoRepository.DeleteContato(id);
        }
    }
}