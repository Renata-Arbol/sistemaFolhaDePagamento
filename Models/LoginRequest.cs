using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using sistemaFolhaDePagamento.Models;

public class LoginRequest
{
    [Required(ErrorMessage = "O campo 'Usuário' é obrigatório.")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
    public string Senha { get; set; }
 
}