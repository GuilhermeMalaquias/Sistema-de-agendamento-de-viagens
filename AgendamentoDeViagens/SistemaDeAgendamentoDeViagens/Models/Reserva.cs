using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class Reserva
    {
        [Key]
        public long? ID_res { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Data_res { get; set; }

        [Required]
        [StringLength(20)]
        public string Linha_aer_res { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float? Preco_res { get; set; }



        public Passageiro Passageiro { get; set; }
        public long? ID_pas { get; set; }
       
        
        public Voo Voo { get; set; }
        public long? ID_voo { get; set; }
    
        

    }
}
