using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Endereco
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        public required string Rua { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public required string Numero { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        public required string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public required string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O Estado deve conter 2 caracteres.")]
        public required string Estado { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter 8 caracteres.")]
        public required string CEP { get; set; }

        [ForeignKey("Empresa")]
        public long? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
       
        [ForeignKey("Funcionario")]
        public long? FuncionarioId { get; set; }

        public Funcionario? Funcionario { get; set; }
    }
}


