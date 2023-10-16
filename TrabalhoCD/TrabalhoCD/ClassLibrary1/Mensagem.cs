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
    public class Mensagem
    {
        
        //Características que definem uma pessoa;
        //Esta vai ser a classe "Pai", ou seja, ou outras classes da biblioteca DTO vão herdar os seus dados;
        #region Parâmetros
        int idOrigem;
        int idSaida;
        int idSaidaGrupo;
        int nova;
        string frase;
        #endregion

        //Aqui é defenido os construtores quando se cria um objecto da classe "Pessoa";
        #region Construtores
        public Mensagem()
        {
            idOrigem = 0;
            idSaida = 0;
            idSaidaGrupo = 0;
            nova = 0;
            frase = "";
        }
        public Mensagem(int idO, int idS, int idSG, int N, string frase)
        {
            IdOrigem = idO;
            IdSaida = idS;
            IdSaidaGrupo = idSG;
            Nova = N;
            Frase = frase;
        }
        #endregion

        //Criar as propriedades que permitem a manipulação dos dados de cada Pessoa;
        #region Propriedades
        public int IdOrigem
        {
            get { return idOrigem; }
            set { if (idOrigem >= 0) idOrigem = value; }
        }

        public int IdSaida
        {
            get { return idSaida; }
            set { if (idSaida >= 0) idSaida = value; }
        }

        public int IdSaidaGrupo
        {
            get { return idSaidaGrupo; }
            set { if (idSaidaGrupo >= 0) idSaidaGrupo = value; }
        }

        public int Nova
        {
            get { return nova; }
            set { nova = value; }
        }

        public string Frase
        {
            get { return frase; }
            set { frase = value; }
        }

        #endregion

        //Defeniçáo da função Override; 
        #region Override
        public override string ToString()
        {
            return String.Format("{0};{1};{2};{3};{4}",
                this.IdOrigem, this.Frase, this.IdSaida, this.IdSaidaGrupo, this.Nova);
        }


        #endregion
    }
}
