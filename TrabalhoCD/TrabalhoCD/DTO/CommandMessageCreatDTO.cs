using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoCD.DTO
{
    public class CommandMessageCreatDTO
    {
        public int Origem { get; set; }

        public string Frase { get; set; }
        public int IdSaida { get; set; }
        public int IdSaidaGrupo { get; set; }
    }
}
