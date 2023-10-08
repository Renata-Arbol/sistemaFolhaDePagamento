using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento.Models
{
    public class Telefone
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [StringLength(20, ErrorMessage = "O campo Número deve ter no máximo 20 caracteres.")]
        public required string Numero { get; set; }

        [StringLength(255, ErrorMessage = "O campo Tipo deve ter no máximo 255 caracteres.")]
        public required string Tipo { get; set; }

        [ForeignKey("Funcionario")]
        public long? FuncionarioId { get; set; }

        public Funcionario? Funcionario { get; set; }
    }
}
