using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace sistemaFolhaDePagamento.Models
{
    public class RegistroPonto
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                 public int Id { get; set; }
                 [Required(ErrorMessage = "O campo DataHora é obrigatório.")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo Tipo deve ter no máximo 50 caracteres.")]
        public required string Tipo { get; set; }
                 [StringLength(255, ErrorMessage = "O campo Observacao deve ter no máximo 255 caracteres.")]
        public string? Observacao { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]        
        [ForeignKey("FuncionarioCargo")]
        public long? FuncionarioCargoId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]  
        public FuncionarioCargo? FuncionarioCargo { get; set; }


    }
}
