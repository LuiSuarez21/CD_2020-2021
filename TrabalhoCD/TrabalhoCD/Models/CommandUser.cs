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

    //Modelo usado para defenir os User;
namespace TrabalhoCD.Models
{
    public class CommandUser
    {
        //Cosntrutores que definem as caracteristicas do nosso user;
        public CommandUser()
        {

        }
        public CommandUser(string primeiroNome, string apelido, string numeroTelemovel, int online, int ligado, string password, string password2, string nomeUtilizador)
        {
            this.PrimeiroNome = primeiroNome;
            this.Apelido = apelido;
            this.NumeroTelemovel = numeroTelemovel;
            this.Online = online;
            this.Ligado = ligado;
            this.Password = password;
            this.Password2 = password2;
            this.NomeUtilizador = nomeUtilizador;
        }

        public string PrimeiroNome { get; set; }
        public string Apelido { get; set; }
        public string NumeroTelemovel { get; set; }
        public int Id { get ; set; }
        public int Online { get; set; }
        public int Ligado { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string NomeUtilizador { get; set; }

    }
}
