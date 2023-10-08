using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using sistemaFolhaDePagamento.Models;

public class Login
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo 'Usuário' é obrigatório.")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
    public string Senha { get; set; }

 
    [ForeignKey("Empresa")]
    public long? EmpresaId { get; set; }

    public Empresa? Empresa { get; set; }

    [ForeignKey("Funcionario")]
    public long? FuncionarioId { get; set; }

    public Funcionario? Funcionario { get; set; }
}