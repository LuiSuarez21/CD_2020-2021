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
    public class Utilizador : Pessoa
    {

        //Aqui define-se as características de um Paciente;
        //Esta classe vai ser defenida de maneira semelhante, adicionando o número de telémovel e o ID;
        #region Parâmetros
        string numerotelemovel;
        int id;
        int online;
        int ligado;
        string password;
        string password2;
        string nome_utilizador;
        #endregion

        //Aqui é defenido os construtores quando se cria um objecto da classe "Paciente";
        #region Construtores
        public Utilizador()
        {
            PrimeiroNome = "";
            Apelido = "";
            numerotelemovel = "";
            id = 0;
            online = 0;
            ligado = 0;
            password = "";
            password2 = "";
            nome_utilizador = "";
        }

        public Utilizador(string primeiro_nome, string apelido, int ID, string numerotelemovel
         , int online, int ligado, string password, string password2, string nome_utilizador)
        {
            this.PrimeiroNome = primeiro_nome;
            this.Apelido = apelido;
            this.id = ID;
            this.numerotelemovel = numerotelemovel;
            this.online = online;
            this.ligado = ligado;
            this.password = password;
            this.password2 = password2;
            this.nome_utilizador = nome_utilizador;
        }
        #endregion

        //Criar as propriedades que permitem a manipulação dos dados de cada paciente;
        #region Propriedades
        public string NumeroTelemovel
        {
            get { return numerotelemovel; }
            set { numerotelemovel = value; }
        }
        public int Idutilizador
        {
            get { return id; }
            set { id = value; }
        }

        public int Online
        {
            get { return online; }
            set { online = value; }
        }
        public int Ligado
        {
            get { return ligado; }
            set { ligado = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Password2
        {
            get { return password2; }
            set { if (password == password2) password2 = value; }
        }
        public string Nome_Utilizador
        {
            get { return nome_utilizador; }
            set { nome_utilizador = value; }
        }
        #endregion

        //Defeniçáo da função Override; 
        #region Override
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                this.PrimeiroNome, this.Apelido, this.numerotelemovel, this.id, this.online, this.ligado, this.password, this.password2, this.nome_utilizador);
        }
        #endregion
    }
}
