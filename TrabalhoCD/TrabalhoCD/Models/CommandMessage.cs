using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */

    //Modelo usado para defenir as Mensagens;
namespace TrabalhoCD.Models
{
    public class CommandMessage
    {
        //Cosntrutores que definem as caracteristicas do nosso user;
        public CommandMessage()
        {

        }
        public CommandMessage(int idOrigem, string frase, int idSaida, int idSaidaGrupo, int nova)
        {
            this.IdOrigem = idOrigem;
            IdSaida = idSaida;
            this.Frase = frase;
            this.IdSaidaGrupo = idSaidaGrupo;
            Nova = nova;
        }

        public int IdOrigem { get; set; }
        public string Frase { get; set; }
        public int IdSaida { get; set; }
        public int IdSaidaGrupo { get; set; }
        public int Nova { get; set; }





    }
}