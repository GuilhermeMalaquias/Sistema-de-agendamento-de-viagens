using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class Passageiro
    {
        [Key]
        public long? PassageiroId { get; set; }

        [Required]
        [StringLength(42)]
        public string Nome_pas { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Data_nasc_pas { get; set; }

        [StringLength(1)]
        public string Sexo_pas { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF_pas { get; set; }

        [Required]
        [StringLength(8)]
        public string Passaporte_pas { get; set; }

        [Required]
        [StringLength(2)]
        public string UF_pas { get; set; }

        [Required]
        [StringLength(50)]
        public string Cidade_pas { get; set; }

        [Required]
        [StringLength(50)]
        public string Bairro_pas { get; set; }

        [Required]
        [DataType(DataType.PostalCode, ErrorMessage = "CEP em formato inválido")]
        public int CEP_pas { get; set; }

        [Required]
        [StringLength(100)]
        public string Email_pas { get; set; }
        public string? Foto_pas { get; set; }


        public virtual ICollection<Reserva> Reservas { get; set;}
    }
}
