using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAgendamentoDeViagens.Models
{
    public class Reserva
    {
        [Key]
        public long? ReservaId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Data_res { get; set; }

        [Required]
        [StringLength(20)]
        public string Linha_aer_res { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco_res { get; set; }



        public Passageiro Passageiro { get; set; }
        public long? PassageiroId { get; set; }
       
        
        public Voo Voo { get; set; }
        public long? VooId { get; set; }
    
        

    }
}
