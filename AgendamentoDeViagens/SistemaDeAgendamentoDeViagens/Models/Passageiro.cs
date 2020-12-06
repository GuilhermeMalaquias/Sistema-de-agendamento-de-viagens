using Microsoft.EntityFrameworkCore;
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
        [StringLength(42, MinimumLength=3, ErrorMessage="O nome deve conter pelo menos 3 caracteres.")]
        public string Nome_pas { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data_nasc_pas { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo_pas { get; set; }

        [Required]
        [StringLength(11, MinimumLength=11, ErrorMessage ="O CPF deve possuir 11 caracteres numericos")]
        public string CPF_pas { get; set; }

        [Required]
        [StringLength(8, MinimumLength=8, ErrorMessage="O Passaporte deve conter duas letras e seis numeros")]
        [RegularExpression(@"^[A-Za-z]{2}[0-9]{6}$", ErrorMessage ="O Passaporte deve conter duas letras seguida de 6 numeros")]
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
        [StringLength(9, MinimumLength=8, ErrorMessage ="O CEP deve conter 8 caracteres numericos.")]
        public string CEP_pas { get; set; }

        [Required]
        [StringLength(100)]
        public string Email_pas { get; set; }


        public virtual ICollection<Reserva> Reservas { get; set;}
    }
}
