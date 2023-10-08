using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Dependente
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data de Nascimento inválida.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Grau de Parentesco é obrigatório.")]
        public required string GrauParentesco { get; set; }


        [ForeignKey("Funcionario")]
        public long? FuncionarioId { get; set; }

        public Funcionario? Funcionario { get; set; }
    }
}
