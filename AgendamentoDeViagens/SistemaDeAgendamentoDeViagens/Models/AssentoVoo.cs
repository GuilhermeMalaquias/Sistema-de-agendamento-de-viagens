using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class AssentoVoo
    {
        public long? Numero_ass { get; set; }

        public long? VooId { get; set; }


        public Assento Assentos { get; set; }
        public Voo Voos { get; set; }
    }
}
