using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoCD.DTO
{
    public class CommandReadDTO
    {
        public string PrimeiroNome { get; set; }
        public string Apelido { get; set; }
        public string NumeroTelemovel { get; set; }
        public int Id { get; set; }
        public int Online { get; set; }
        public int Ligado { get; set; }
        public string Password { get; set; }

        //Desnecessário de ler;
        //public string Password2 { get; set; }
        public string NomeUtilizador { get; set; }
    }
}
