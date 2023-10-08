using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.DTOS
{
public class LoginDto 
{
    public string Usuario { get; set; }
    public string Senha { get; set; }
}
}