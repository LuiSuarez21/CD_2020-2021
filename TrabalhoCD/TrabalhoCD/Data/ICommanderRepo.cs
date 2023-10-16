using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCD.Models;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */
namespace TrabalhoCD.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<CommandUser> GetAllCommands();
        CommandUser GetCommandById(int id);
        void CreateCommmand(CommandUser c);
        public int UpdateCommand(CommandUser us);
        public int DeleteCommand(int id);
        IEnumerable<CommandMessage> GetAllMessages();
        CommandMessage GetMessageById(int id);
        void CreateMessage(CommandMessage m);
        public void UpdateMessage(CommandMessage m);
        public void DeleteMessage(CommandMessage m);

    }
}
