using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Cargo
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo JornadaTrabalhoHoras é obrigatório.")]
        public int JornadaTrabalhoHoras { get; set; }

        [Required(ErrorMessage = "O campo SalarioMensal é obrigatório.")]
        [DataType(DataType.Currency)]
        public decimal SalarioMensal { get; set; }

        [Required(ErrorMessage = "O campo SalarioHora é obrigatório.")]
        [DataType(DataType.Currency)]
        public decimal SalarioHora { get; set; }
       
    
        public ICollection<FuncionarioCargo>? FuncionariosCargos { get; set; }

    }
}
