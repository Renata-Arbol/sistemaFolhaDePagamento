using System;
using System.ComponentModel.DataAnnotations;

namespace sistemaFolhaDePagamento.Models
{
    public class TipoEmail
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Nome { get; set; }

        // Outras propriedades relacionadas ao tipo de email, se necessário
    }
}
