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

    //Controller dos User;
namespace TrabalhoCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    { 

        private readonly ICommanderRepo _logger;
        private readonly IMapper _mapper;


        public UserController(ICommanderRepo logger,IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper; 
        }
       
        
        //GET api;
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _logger.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
        }
        
        //GET id;
        //Vai buscar dados sobre o utilizador;
        [HttpGet("{id}")]
        public ActionResult <CommandReadDTO> GetCommandById (int id)
        {
            var commandItem = _logger.GetCommandById(id);
            if (commandItem != null && id < 5)return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            else
            //meter metodo que vai ao ficheiro, ve se existe, e retorna entao valor adequado
            {
                return NotFound();
            }
        }

        //POST api
        //Imprime dados do utilizador
        [HttpPost]
        public ActionResult <CommandReadDTO> CreateCommand(CommandCreatDTO commandcreatDto)
        {
            var commandModel = _mapper.Map<CommandUser>(commandcreatDto);
            _logger.CreateCommmand(commandModel);
            if (commandModel != null)return Ok(commandModel);
            else
            //meter metodo que vai ao ficheiro, ve se existe, e retorna entao valor adequado
            {
                return NoContent();
            }
        }
        //PUT id
        [HttpPut]
        public ActionResult <CommandUpdateDTO> UpdateCommand(CommandUpdateDTO commandUpdate)
        {
            var commandModel = _mapper.Map<CommandUser>(commandUpdate);
            int aux = _logger.UpdateCommand(commandModel);
            if (commandModel != null && aux == 1) return Ok(commandModel);
            else
            {
                return NotFound();
            }
            
        }

        //DELETE id
        [HttpDelete]
        public ActionResult DeleteCommand (int Id)
        {
            int aux = _logger.DeleteCommand(Id);
            if (aux == 1) return NoContent();
            else
            {
                return NotFound();
            }
        }
    }
}
