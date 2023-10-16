using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCD.DTO;
using TrabalhoCD.Models;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */
namespace TrabalhoCD.Profiles
{
    public class CommandsProfile : Profile
    {
         public CommandsProfile()
         {
            //Source-> Target
            CreateMap<CommandUser, CommandReadDTO>();
            CreateMap<CommandCreatDTO, CommandUser>();
            CreateMap<CommandUpdateDTO, CommandUser>();
            CreateMap<CommandMessage, CommandMessageReadDTO>();
            CreateMap<CommandMessageCreatDTO, CommandMessage>();
            CreateMap<CommandMessageUpdateDTO, CommandMessage>();
        }
    }
}
