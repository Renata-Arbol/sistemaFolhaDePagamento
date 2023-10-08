using sistemaFolhaDePagamento.Models;
using Microsoft.EntityFrameworkCore;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.Seed
{
public class SeedData
{
    private readonly ApplicationDbContext _context;

    public SeedData(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Initialize()
    {

        if (_context.Empresas.Any())
        {
            return;   // O banco de dados já foi semeado com empresas
        }

        // Defina as empresas como variáveis
        var empresa1 = new Empresa { Nome = "Empresa 1", Cnpj = "12345678000101", RazaoSocial = "Empresa 1 Ltda", Telefone = "11987654321" };
        var empresa2 = new Empresa { Nome = "Empresa 2", Cnpj = "12345678000102", RazaoSocial = "Empresa 2 Ltda", Telefone = "11987654322" };
        var empresa3 = new Empresa { Nome = "Empresa 3", Cnpj = "12345678000103", RazaoSocial = "Empresa 3 Ltda", Telefone = "11987654323" };
        var empresa4 = new Empresa { Nome = "Empresa 4", Cnpj = "12345678000104", RazaoSocial = "Empresa 4 Ltda", Telefone = "11987654324" };
        var empresa5 = new Empresa { Nome = "Empresa 5", Cnpj = "12345678000105", RazaoSocial = "Empresa 5 Ltda", Telefone = "11987654325" };
        var empresa6 = new Empresa { Nome = "Empresa 6", Cnpj = "12345678000106", RazaoSocial = "Empresa 6 Ltda", Telefone = "11987654326" };
        var empresa7 = new Empresa { Nome = "Empresa 7", Cnpj = "12345678000107", RazaoSocial = "Empresa 7 Ltda", Telefone = "11987654327" };
        var empresa8 = new Empresa { Nome = "Empresa 8", Cnpj = "12345678000108", RazaoSocial = "Empresa 8 Ltda", Telefone = "11987654328" };
        var empresa9 = new Empresa { Nome = "Empresa 9", Cnpj = "12345678000109", RazaoSocial = "Empresa 9 Ltda", Telefone = "11987654329" };
        var empresa10 = new Empresa { Nome = "Empresa 10", Cnpj = "12345678000110", RazaoSocial = "Empresa 10 Ltda", Telefone = "11987654330" };

        // Adicione as empresas ao contexto
        _context.Empresas.AddRange(empresa1, empresa2, empresa3, empresa4, empresa5, empresa6, empresa7, empresa8, empresa9, empresa10);

        // Salve as mudanças no banco de dados
        _context.SaveChanges();
    }
}
}

