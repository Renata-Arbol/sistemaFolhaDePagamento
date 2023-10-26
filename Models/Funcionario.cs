using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace sistemaFolhaDePagamento.Models
{
    public class Funcionario
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        public required string Sexo { get; set; }
        
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public required string Telefone { get; set; }


        [Required(ErrorMessage = "O campo DataNascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime DataNascimento { get; set; }
        public long? DocumentoId { get; set; }

        public Documento? Documento { get; set; }


        public ICollection<Contato>? Contatos { get; set; }

        public ICollection<Dependente>? Dependentes { get; set; }


        public ICollection<FuncionarioCargo>? FuncionariosCargos { get; set; }
        public ICollection<Endereco>? Enderecos { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("Login")]
        public long? LoginId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Login? Login { get; set; }


        [ForeignKey("Empresa")]
        public long EmpresaId { get; set; }

        public Empresa Empresa { get; set; }
    }
}
