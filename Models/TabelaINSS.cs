using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace sistemaFolhaDePagamento.Models
{
    public class TabelaINSS
    {
        [Key]
        [Column("auto_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DataType(DataType.Currency)]
        public decimal Aliquota { get; set; }

        [DataType(DataType.Currency)]
        public decimal FaixaInicial { get; set; }

        [DataType(DataType.Currency)]
        public decimal FaixaFinal { get; set; }

       
    }
}
