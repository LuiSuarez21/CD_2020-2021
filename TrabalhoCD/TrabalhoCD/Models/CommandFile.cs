using Microsoft.AspNetCore.Http;
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

    //Modelo para defenir os Ficheiros;
namespace TrabalhoCD.Models
{
    public class CommandFile
    {
        public IFormFile files { get; set; }
    }
}
