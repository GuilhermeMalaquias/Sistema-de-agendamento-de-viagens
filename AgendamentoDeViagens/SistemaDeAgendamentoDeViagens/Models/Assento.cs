using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class Assento
    {
        [Key]
        [Required]
        public int Numero_ass { get; set; }

        [Required]
        [StringLength(20)]
        public string Classe_ass { get; set; }


        public virtual ICollection<AssentoVoo> AssentoVoos { get; set; }



    }
}
