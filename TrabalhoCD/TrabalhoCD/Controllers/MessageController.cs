using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCD.Models;
using TrabalhoCD.Data;
using TrabalhoCD.DTO;
using AutoMapper;
using System.Text.Json;
using Newtonsoft.Json;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */

    //Controller das Menssagens
namespace TrabalhoCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly ICommanderRepo _logger;
        private readonly IMapper _mapper;


        public MessageController(ICommanderRepo logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }


        //GET api;
        [HttpGet]
        public ActionResult<IEnumerable<CommandMessageReadDTO>> GetAllMessages()
        {
            var commandItems = _logger.GetAllMessages();
            return Ok(_mapper.Map<IEnumerable<CommandMessageReadDTO>>(commandItems));
        }

        //GET id;
        //Vai buscar dados sobre o utilizador;
        [HttpGet("{id}")]
        public ActionResult<CommandMessageReadDTO> GetCommandById(int id)
        {
            var commandItem = _logger.GetCommandById(id);
            if (commandItem != null && id < 5) return Ok(_mapper.Map<CommandMessageReadDTO>(commandItem));
            else
            //meter metodo que vai ao ficheiro, ve se existe, e retorna entao valor adequado
            {
                return NotFound();
            }
        }

        //POST api
        //Imprime dados do utilizador
        [HttpPost]
        public ActionResult<CommandMessageReadDTO> CreateMessage(CommandMessageCreatDTO commandcreatDto)
        {
            var commandModel = _mapper.Map<CommandMessage>(commandcreatDto);
            _logger.CreateMessage(commandModel);
            if (commandModel != null) return Ok(commandModel);
            else
            //meter metodo que vai ao ficheiro, ve se existe, e retorna entao valor adequado
            {
                return NoContent();
            }
        }
        //PUT id
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandMessageUpdateDTO commandUpdate)
        {
            var commandModelFromRepo = _logger.GetMessageById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }

        //DELETE id
        [HttpDelete]
        public ActionResult DeleteMessage(int Id)
        {
            var commandModelFromRepo = _logger.GetMessageById(Id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _logger.DeleteMessage(commandModelFromRepo);
            return NoContent();
        }
    }
}

