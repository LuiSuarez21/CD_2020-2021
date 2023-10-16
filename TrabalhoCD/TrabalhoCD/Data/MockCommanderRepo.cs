using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoCD.Models;
using ClassLibrary1;
using System.IO;
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
    public class MockCommanderRepo : ICommanderRepo
    {

        //Função que cria um novo user;
        public void CreateCommmand(CommandUser c)
        {
            string caminhoficheiro = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Covid.txt";
            string caminhoficheiro2 = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Login.txt";
            c.Ligado = 1;
            CommandUser cmd = new CommandUser(c.PrimeiroNome, c.Apelido, c.NumeroTelemovel, c.Online, c.Ligado, c.Password, c.Password2, c.NomeUtilizador);
            Utilizador u = new Utilizador(c.PrimeiroNome, c.Apelido, c.Id, c.NumeroTelemovel, c.Online, c.Ligado, c.Password, c.Password2, c.NomeUtilizador);
            AcessoDados.AdicionarClientes(u);
            AcessoDados.RegistroClientes(caminhoficheiro, caminhoficheiro2);
        }

        //Experiência com o GET;
        public IEnumerable<CommandUser> GetAllCommands()
        {
            string caminhoficheiro = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Covid.txt";
            string caminhoficheiro2 = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Login.txt";
            var commands = new List<CommandUser>
            {
                new CommandUser {PrimeiroNome = "Luis", Apelido = "Esteves", NumeroTelemovel = "939435791", Id = 0, Online = 1, Ligado = 1, Password = "ma", Password2 = "ma", NomeUtilizador = "luisesteves"}
            };
            Utilizador u = new Utilizador("Luis", "Esteves", 0, "939435791", 1, 1, "ma", "ma", "luisesteves");
            AcessoDados.AdicionarClientes(u);
            AcessoDados.RegistroClientes(caminhoficheiro, caminhoficheiro2);
            return commands;
        }

        //Encontra um User pelo Id
        public CommandUser GetCommandById(int Id)
        {
            Utilizador u2 = new Utilizador("Jose", "Cunha", Id, "939435791", 1, 1, "ma", "ma", "luisesteves");
            string caminhoficheiro = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Covid.txt";
            string caminhoficheiro2 = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Login.txt";
            //u2 = AcessoDados.ConsultarListaUtilizadores(Id);
            return new CommandUser { PrimeiroNome = u2.PrimeiroNome, Apelido = u2.Apelido , NumeroTelemovel = u2.NumeroTelemovel, Id = u2.Idutilizador, Online = u2.Online, Ligado = u2.Ligado, Password = u2.Password, Password2 = u2.Password2, NomeUtilizador = u2.Nome_Utilizador };
        }

        //Apanha o User que procura, elimina a password e faz apdate;
        public int UpdateCommand(CommandUser us)
        {
            us.Online = 0;
            us.Ligado = 1;
            Utilizador u = new Utilizador(us.PrimeiroNome, us.Apelido, us.Id, us.NumeroTelemovel,  us.Online, us.Ligado, us.Password,  us.Password2, us.NomeUtilizador);
            int aux = AcessoDados.ConsultarUtilizadores2(u.Idutilizador, u);
            int aux2 = AcessoDados.ConsultarUtilizadores(u.Idutilizador, u);
            if (aux == aux2 && aux2 == 0) return 0;
            else { return 1; }
        }

        //Elimina o user;
        public int DeleteCommand(int id)
        {
            int aux = AcessoDados.Delete1(id);
            int aux2 = AcessoDados.Delete2(id);
            if (aux == aux2 && aux2 == 0) return 0;
            else { return 1; }
        }


        //Experiência com o GET;
        public IEnumerable<CommandMessage> GetAllMessages()
        {

            var commands = new List<CommandMessage>
            {
                new CommandMessage { IdOrigem = 0, Frase = "Ola", IdSaida = 1}
            };
            return commands;
        }

        //Encontra um User pelo Id
        public CommandMessage GetMessageById(int Id)
        {

            return new CommandMessage { IdOrigem = Id, Frase = "Adeus", IdSaida = 1 };
        }

        //Apanha o User que procura, elimina e faz update;
        public void UpdateMessage(CommandMessage us)
        {

        }

        //Elimina o user;
        public void DeleteMessage(CommandMessage us)
        {

        }

        public void CreateMessage(CommandMessage m)
        {
            string caminhoficheiro = @"C:\Users\jlce1\Desktop\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Message.txt";
            Mensagem mens = new Mensagem(m.IdOrigem, m.IdSaida, m.IdSaidaGrupo, m.Nova, m.Frase);
            AcessoDados2.AdicionarMensagem(mens);
            AcessoDados2.RegistroMensagem(caminhoficheiro);
            new CommandMessage { IdOrigem = m.IdOrigem, Frase = m.Frase, IdSaida = m.IdSaida, IdSaidaGrupo = m.IdSaidaGrupo, Nova = m.Nova};
        }
    }
}
