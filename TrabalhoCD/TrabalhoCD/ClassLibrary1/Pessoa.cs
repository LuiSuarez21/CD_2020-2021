using System;
using System.Collections.Generic;
using System.Text;
/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */
namespace ClassLibrary1
{
    public class Pessoa
    {
        //Características que definem uma pessoa;
        //Esta vai ser a classe "Pai", ou seja, ou outras classes da biblioteca DTO vão herdar os seus dados;
        #region Parâmetros
        string primeiro_nome;
        string apelido;
        #endregion

        //Aqui é defenido os construtores quando se cria um objecto da classe "Pessoa";
        #region Construtores
        public Pessoa()
        {
            primeiro_nome = "";
            apelido = "";
        }
        public Pessoa(string primeiro_nome, string apelido)
        {
            this.primeiro_nome = primeiro_nome;
            this.apelido = apelido;
        }
        #endregion

        //Criar as propriedades que permitem a manipulação dos dados de cada Pessoa;
        #region Propriedades
        public string PrimeiroNome
        {
            get { return primeiro_nome; }
            set { if (primeiro_nome.Length < 20) primeiro_nome = value; }
        }

        public string Apelido
        {
            get { return apelido; }
            set { if (apelido.Length < 20) apelido = value; }
        }

        #endregion
    }
}
