using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class PassageiroViewModel
    {
        public string Nome_pas { get; set; }

        public DateTime? Data_nasc_pas { get; set; }


        public string Sexo_pas { get; set; }


        public string CPF_pas { get; set; }

        public string Passaporte_pas { get; set; }

        public string UF_pas { get; set; }

        public string Cidade_pas { get; set; }

        public string Bairro_pas { get; set; }

        public int CEP_pas { get; set; }

        public string Email_pas { get; set; }
        public IFormFile Foto_pas { get; set; }
    }
}
