using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class Voo
    {
        [Key]
        public long? VooId { get; set; }

        [Required]
        [StringLength(50)]
        public string Origem_voo { get; set; }

        [Required]
        [StringLength(50)]
        public string Destino_voo { get; set; }

        [Required]
        [StringLength(180)]
        public string Descricao_voo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Data_partida_voo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Data_chegada_voo { get; set; }
        [Required]
        public bool Top_voo { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
