/*
 * 
 * Autores do projecto: Luis Esteves/16960 || Sérgio Ribeiro/18858 || João Riberio/17214;
 * Disciplina: Comunicação de dados;
 * Projecto II;
 * Propósito do trabalho: Criar uma API de gerência de utilizadores e de mensagens
 *
 */
using System;
using System.Collections.Generic;
using System.IO;

/*
 Permitir alterar a palavra-chave de um utilizador. 
 Remover um utilizador, isto é, remover todas as informações guardadas no
servidor para esse utilizador.
*/

// A biblioteca DAL (Data Access Layer) serve como a biblioteca que acessa ao banco de dados e todas as operações da manipulação da mesma;

/// <summary>
/// É nesta classe que é feito o acesso ao banco de dados, neste caso, a listaCovid, onde vão ser guardados todos os dados relativos aos pacientes;
/// Todas as operações que envolvam a manipulação dessa mesma lista, consulta, adição ou remoção, é feita nesta classe;
/// </summary>

namespace ClassLibrary1
{
    public class AcessoDados
    {
        //Aqui criamos a lista onde vamos guardar a imformação dos Clientes
        #region Parâmetros
        static List<Utilizador> listaClientes;
        #endregion

        //Inicialização dessa mesma lista;
        #region Construtores
        static AcessoDados()
        {
            listaClientes = new List<Utilizador>();
        }
        #endregion

        //Este método adiciona membros na lista Utilizador;
        public static bool AdicionarClientes(Utilizador c)
        {
         int t = 0;
            // Este ciclo for serve para verficar se já existe um objeto com a mesma imformação na lista;
            // Se houver, então o objeto não é adicionado;
            for (int i = 0; i <= listaClientes.Count; i++)
            {
                if (listaClientes.Count == 0)
                {
                    listaClientes.Add(c);
                    t = 1;
                }
                if (listaClientes.Count != 0)
                {
                    if (i != listaClientes.Count && listaClientes[i].Idutilizador == c.Idutilizador) t = 1;
                }
                if (t == 0 && i == listaClientes.Count)
                {
                    listaClientes.Add(c);
                    t = 1;
                }
            }
            return true;
        }

        //É necessário meter o caminho do ficheiro na mesma;
        #region Métodos de Escrita dos Ficheiros

        public static int GeradordeId(string ficheiro)
        {
            int id = 0;
            string[] lines = File.ReadAllLines(ficheiro);
            foreach (var line in lines)
            {
                id++;
            }
            return id;
        }

        // Este método registra as imformações pretendidas nos ficheiros, imformações relacionadas com os pacientes que têm Covid;
        public static bool RegistroClientes(string caminhoficheiro, string caminhoficheiro2)
        {
            int gerador = GeradordeId(caminhoficheiro);
            StreamWriter sw = new StreamWriter(caminhoficheiro, true);
            StreamWriter sw2 = new StreamWriter(caminhoficheiro2, true);
            int t = 0;
            for (int i = 0; i < listaClientes.Count; i++)
            {
                if (listaClientes[i] == null)
                {
                    sw.Close();
                    sw2.Close();
                    i = listaClientes.Count + 1;
                }

                if (listaClientes[i].Password != "")
                {
                    if (File.Exists(caminhoficheiro) == true && File.Exists(caminhoficheiro2) == true)
                    {

                        if (t == 0 && i == listaClientes.Count - 1)
                        {

                            listaClientes[i].Idutilizador = gerador;
                            sw.WriteLine(listaClientes[i].ToString());
                            sw.Close();
                            sw2.WriteLine(ToString(i));
                            sw2.Close();
                            t = 1;
                            return true;
                            
                        }
                        
                    }
                    else
                    {
                        sw = File.CreateText(caminhoficheiro);
                        sw.WriteLine(listaClientes[i].ToString());
                        sw.Close();
                        sw2 = File.CreateText(caminhoficheiro2);
                        sw2.WriteLine(ToString(i));
                        sw2.Close();
                        return true;
                    }
                }
            }

            return true;

        }
        #endregion

        //Nestes métodos dá-se a leitrua dos ficheiros de texto;
        #region Métodos de Leitura dos Ficheiros

        /*
        public static Utilizador ConsultarUtilizadores(int id, string password)
        {
            int t = 0;
            string caminhoficheiro = @"C:\Users\josel\OneDrive\Ambiente de Trabalho\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Covid.txt";
            string[] lines = File.ReadAllLines(caminhoficheiro);
            string  
            int f, i, p, aux, l;
            f = i = p = aux = l = 0;
            int line2 = 1000;
            foreach (var line in lines)
            {
                string lineaux = line;
                for (i = 0; lineaux.Length > i; i++)
                {
                    //this.PrimeiroNome, this.Apelido, this.numerotelemovel, this.id, this.online, this.ligado, this.password, this.password2, this.nome_utilizador);
                if (line == "/0") aux = 1;
                else if (aux != 1 && lineaux != ";") ;
                    
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

            for ( i = 0; i <= listaClientes.Count; i++)
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
        public static int ConsultarUtilizadores(int id, Utilizador u)
        {
            string caminho = @"C:\Users\josel\OneDrive\Ambiente de Trabalho\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Covid.txt";
            int aux = 0;
            string[] lines = File.ReadAllLines(caminho);
            foreach (var line in lines)
            {
                aux++;
            }
            if (aux == 0) return aux;

            else
            {

                int indice = id;
                int i, f;
                f = i = 0;
                listaClientes.Add(u);
                listaClientes[i].PrimeiroNome = u.PrimeiroNome;
                listaClientes[i].Apelido = u.Apelido;
                listaClientes[i].Online = u.Online;
                listaClientes[i].Ligado = u.Ligado;
                listaClientes[i].Password2 = u.Password2;
                listaClientes[i].Password = u.Password;
                listaClientes[i].NumeroTelemovel = u.NumeroTelemovel;
                listaClientes[i].Idutilizador = u.Idutilizador;
                listaClientes[i].Nome_Utilizador = u.Nome_Utilizador;


                if (indice > -1)
                {

                    using (var input = File.OpenText(caminho))
                    using (var output = new StreamWriter("Covid.txt"))
                    {
                        string linhaAtual;
                        while ((linhaAtual = input.ReadLine()) != null)
                        {
                            if (indice != f)
                            {
                                output.WriteLine(linhaAtual);
                            }
                            if (indice == f)
                            {
                                output.WriteLine(listaClientes[i].ToString());
                            }
                            f++;
                        }

                    }


                    File.Delete(caminho); // Deleta o arquivo original
                    File.Move("Covid.txt", caminho); // Substitui o original pelo modificado
                    return aux;
                }
            }
            return aux;
        }

        public static int ConsultarUtilizadores2(int id, Utilizador u)
        {
            string caminho = @"C:\Users\josel\OneDrive\Ambiente de Trabalho\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Login.txt";
            int aux = 0;
            string[] lines = File.ReadAllLines(caminho);
            foreach (var line in lines)
            {
                aux++;
            }
            if (aux == 0)return aux;

            else { 

            int indice = id;
            int i = 0;
            listaClientes.Add(u);
            listaClientes[i].Password = listaClientes[id].Password2 = u.Password;
            listaClientes[i].NumeroTelemovel = u.NumeroTelemovel;

                if (indice > -1)
                {

                    using (var input = File.OpenText(caminho))
                    using (var output = new StreamWriter("Login.txt"))
                    {
                        string linhaAtual;
                        while ((linhaAtual = input.ReadLine()) != null)
                        {
                            if (indice != i)
                            {
                                output.WriteLine(linhaAtual);
                            }
                            if (indice == i)
                            {
                                output.WriteLine(ToString(indice));
                            }
                            i++;
                        }

                    }


                    File.Delete(caminho); // Deleta o arquivo original
                    File.Move("Login.txt", caminho); // Substitui o original pelo modificado

                    return aux;
                }
            }
            return aux;
        }
        #endregion

        //Nestes métodos dá-se a eliminação de utilizadores;
        #region Deletar utilizadores

        public static int Delete1(int id)
        {
            string caminho = @"C:\Users\josel\OneDrive\Ambiente de Trabalho\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Login.txt";
            int aux = 0;
            string[] lines = File.ReadAllLines(caminho);
            foreach (var line in lines)
            {
                aux++;
            }
            if (aux == 0 || aux <= id)
            {
                aux = 0;
                return aux;
            }
            else
            {
                int indice = id;
                int i = 0;


                if (indice > -1)
                {

                    using (var input = File.OpenText(caminho))
                    using (var output = new StreamWriter("Login.txt"))
                    {
                        string linhaAtual;
                        while ((linhaAtual = input.ReadLine()) != null)
                        {
                            if (indice != i)
                            {
                                output.WriteLine(linhaAtual);
                            }

                            i++;
                        }

                    }
                    File.Delete(caminho); // Deleta o arquivo original
                    File.Move("Login.txt", caminho); // Substitui o original pelo modificado
                    return aux;
                }
            }
            return aux;
        }

        public static int Delete2(int id)
        {
            string caminho = @"C:\Users\josel\OneDrive\Ambiente de Trabalho\LESI\2º ano\2 Semestre\Comunicação de dados\TPF\TrabalhoCD\TrabalhoCD\Ficheiros de texto\Covid.txt";
            int aux = 0;
            string[] lines = File.ReadAllLines(caminho);
            foreach (var line in lines)
            {
                aux++;
            }
            if (aux == 0 || aux <= id)
            {
                aux = 0;
                return aux;
            }
            else
            {

                int indice = id;
                int i = 0;


                if (indice > -1)
                {

                    using (var input = File.OpenText(caminho))
                    using (var output = new StreamWriter("Covid.txt"))
                    {
                        string linhaAtual;
                        while ((linhaAtual = input.ReadLine()) != null)
                        {
                            if (indice != i)
                            {
                                output.WriteLine(linhaAtual);
                            }
                            i++;
                        }

                    }
                    File.Delete(caminho); // Deleta o arquivo original
                    File.Move("Covid.txt", caminho); // Substitui o original pelo modificado
                }
                return aux;
            }
            return aux;
        }

        #endregion
        public static string ToString(int i)
        {

            return String.Format("{0};{1}",
                listaClientes[i].NumeroTelemovel, listaClientes[i].Password);
        }

    }
}
