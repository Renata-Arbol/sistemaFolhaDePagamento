using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Empresa
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo Cnpj é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve conter 14 dígitos.")]
        public required string Cnpj { get; set; }

        public required string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [Phone(ErrorMessage = "O número de telefone não é válido.")]
        public required string Telefone { get; set; }
     
        public ICollection<Endereco>? Enderecos { get; set; }

        public ICollection<Departamento>? Departamentos { get; set; }


        public ICollection<Funcionario>? Funcionarios { get; set; } 
    }
}
