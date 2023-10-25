using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace sistemaFolhaDePagamento.Models
{
    public class Pagamento
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo Valor Líquido é obrigatório.")]
        public required double ValorLiquido { get; set; }
      
    }
}
