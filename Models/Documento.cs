using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Documento
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        [StringLength(20, ErrorMessage = "O RG deve conter no máximo 20 caracteres.")]
        public required string RG { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 dígitos.")]
        public required string CPF { get; set; }
        
        [Required(ErrorMessage = "O campo Data de Emissão é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data de Emissão inválida.")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "O campo Orgão Emissor é obrigatório.")]
        [StringLength(10, ErrorMessage = "O Orgão Emissor deve conter no máximo 10 caracteres.")]
        public required string OrgaoEmissor { get; set; }

        [Required(ErrorMessage = "O campo Estado Emissor é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O Estado Emissor deve conter 2 caracteres.")]
        public required string EstadoEmissor { get; set; }

        [Required(ErrorMessage = "O campo País Emissor é obrigatório.")]
        public required string PaisEmissor { get; set; }
       
        [ForeignKey("Funcionario")]
        public long? FuncionarioId { get; set; }
     
        public Funcionario? Funcionario { get; set; }


        [Required(ErrorMessage = "O campo Estado Civil é obrigatório.")]
        public required string EstadoCivil { get; set; }
        
        [Required(ErrorMessage = "O campo Nacionalidade é obrigatório.")]
        public required string Nacionalidade { get; set; }
        
        public string PIS { get; set; }

        public string RNE { get; set; }


        public  string NoCtps { get; set; }
    }
}
