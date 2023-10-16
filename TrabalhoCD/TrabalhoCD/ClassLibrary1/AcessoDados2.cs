using System.Collections.Generic;
using System.IO;
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
    public class AcessoDados2
    {
        //Aqui criamos a lista onde vamos guardar a imformação dos Clientes
        #region Parâmetros
        static List<Mensagem> listaMensagens;
        #endregion

        //Inicialização dessa mesma lista;
        #region Construtores
        static AcessoDados2()
        {
            listaMensagens = new List<Mensagem>();
        }
        #endregion

        //Este método adiciona membros na lista Utilizador;
        public static bool AdicionarMensagem(Mensagem m)
        {
            int t = 0;
            // Este ciclo for serve para verficar se já existe um objeto com a mesma imformação na lista;
            // Se houver, então o objeto não é adicionado;
            for (int i = 0; i <= listaMensagens.Count; i++)
            {
                if (listaMensagens.Count == 0)
                {
                    listaMensagens.Add(m);
                    t = 1;
                }
                if (listaMensagens.Count != 0)
                {
                    if (i != listaMensagens.Count && listaMensagens[i].Frase == m.Frase) t = 1;
                }
                if (t == 0 && i == listaMensagens.Count)
                {
                    listaMensagens.Add(m);
                    t = 1;
                }
            }
            return true;
        }


        #region Métodos de Escrita
        // Este método registra as imformações pretendidas nos ficheiros, imformações relacionadas com os pacientes que têm Covid;
        public static bool RegistroMensagem(string caminhoficheiro)
        {
            StreamWriter sw = new StreamWriter(caminhoficheiro, true);
            int t = 0;
            for (int i = 0; i < listaMensagens.Count; i++)
            {
                if (listaMensagens[i] == null)
                {
                    sw.Close();
                    i = listaMensagens.Count + 1;
                }

                if (listaMensagens[i].Frase != "")
                {
                    if (File.Exists(caminhoficheiro) == true)
                    {

                        if (t == 0 && i == listaMensagens.Count - 1)
                        {

                            sw.WriteLine(listaMensagens[i].ToString());
                            sw.Close();
                            t = 1;
                            return true;

                        }

                    }
                    else
                    {
                        sw = File.CreateText(caminhoficheiro);
                        sw.WriteLine(listaMensagens[i].ToString());
                        sw.Close();
                        return true;
                    }
                }
            }

            return true;

        }
        #endregion

        #region Métodos de Leitura

        /*
        public static int ConsultarMensagens(int idSaida)
        {
            int t = 0;
            string caminhoficheiro = @"C:\Users\josel\OneDrive\Ambiente de Trabalho\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Message.txt";
            string[] lines = File.ReadAllLines(caminhoficheiro);
            string ajuda;
            int f, i, p, aux, l;
            f = i = p = aux = l = 0;
            int line2 = 1000;
            foreach (var line in lines)
            {
                string lineaux = line;
                for (i = 0; lineaux.Length > i; i++)
                {
                    ajuda = lineaux;
                    if (ajuda [i] == ";")
                }

                for (i = 0; lineaux.Length > i; i++)
                {
                    if ( ) aux = 1;
                    else if (aux != 1 && lineaux != ";") 

                }

                if (f == 9)
                {
                    for (i = f + 1; lineaux.Length > i; i++)
                    {

                        if (password.Length > aux && lineaux[i] != password[aux]) break;
                        else if (password.Length > aux && lineaux[i] == password[aux])
                        {
                            p++;
                            aux++;
                        }
                    }
                }
                if (p == password.Length && f == 9) line2 = l;
                l++;
            }

            for (i = 0; i <= listaClientes.Count; i++)
            {
                if (listaClientes.Count == 0)
                {
                    t = 1;
                    return null;
                }
                if (t == 0 && listaClientes[i].Idutilizador == id)
                {

                    t = 1;
                    return listaClientes[i];
                }

            }
        }
        */
        #endregion
    }
}
