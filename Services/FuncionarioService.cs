using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;

public class FuncionarioService  : sistemaFolhaDePagamento.Service.IFuncionarioService
{
    private readonly ApplicationDbContext _context;

    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Funcionario> GetFuncionarios()
    {
        return _context.Funcionarios.ToList();
    }

    public Funcionario GetFuncionarioById(long id)
    {
        return _context.Funcionarios.Include(l => l.Documento).FirstOrDefault(f => f.Id == id);
     
    }

    public void CreateFuncionario(Funcionario funcionario)
    {
        if (funcionario == null)
        {
            throw new ArgumentNullException(nameof(funcionario));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(funcionario);
    }

    public void UpdateFuncionario(long id, Funcionario funcionario)
    {
        var existingFuncionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

        if (existingFuncionario == null)
        {
            throw new InvalidOperationException($"Funcionário com ID {id} não encontrado.");
        }

        // Atualize as propriedades do funcionário existente com as propriedades do novo funcionário
        existingFuncionario.Nome = funcionario.Nome;
        existingFuncionario.DataNascimento = funcionario.DataNascimento;
        //existingFuncionario.Documento = funcionario.Documento; 
        //existingFuncionario.Contatos = funcionario.Contatos;
        //existingFuncionario.Dependentes = funcionario.Dependentes;
        //existingFuncionario.Enderecos = funcionario.Enderecos;

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteFuncionario(long id)
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

        if (funcionario == null)
        {
            throw new InvalidOperationException($"Funcionário com ID {id} não encontrado.");
        }

        _context.Funcionarios.Remove(funcionario);
        _context.SaveChanges();
    }
}
