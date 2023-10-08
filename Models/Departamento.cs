using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Departamento
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public required string Descricao { get; set; }
        
 
        [ForeignKey("Empresa")]
        public long? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }

        public ICollection<Cargo>? Cargos { get; set; }
    }
}





