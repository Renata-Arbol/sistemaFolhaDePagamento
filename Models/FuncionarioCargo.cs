using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace sistemaFolhaDePagamento.Models
{
    public class FuncionarioCargo
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                 public long Id { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("Funcionario")]
        public long? FuncionarioId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Funcionario? Funcionario { get; set; }
        
                 [ForeignKey("Cargo")]
        public long? CargoId { get; set; }
                 public Cargo? Cargo { get; set; }
        
                 public ICollection<RegistroPonto>? RegistroPontos { get; set; }
                 public DateTime? DataInicio { get; set; }
                 public DateTime? DataFim { get; set; }
        public int Atual { get; set; }
    }
}
