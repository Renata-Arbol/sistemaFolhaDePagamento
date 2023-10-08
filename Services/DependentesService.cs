using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;

public class DependenteService  : sistemaFolhaDePagamento.Service.IDependenteService
{
    private readonly ApplicationDbContext _context;

    public DependenteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Dependente> GetDependentes()
    {
        return _context.Dependentes.ToList();
    }

    public Dependente GetDependenteById(long id)
    {
        return _context.Dependentes.FirstOrDefault(d => d.Id == id);
    }

    public void CreateDependente(Dependente dependente)
    {
        if (dependente == null)
        {
            throw new ArgumentNullException(nameof(dependente));
        }


        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(dependente);
    }

    public void UpdateDependente(long id, Dependente dependente)
    {
        if (dependente == null)
        {
            throw new ArgumentNullException(nameof(dependente));
        }

        var existingDependente = _context.Dependentes.FirstOrDefault(d => d.Id == id);

        if (existingDependente == null)
        {
            throw new InvalidOperationException($"Dependente com ID {id} não encontrado.");
        }

        // Atualize as propriedades do dependente existente com as propriedades do novo dependente
        existingDependente.Nome = dependente.Nome;
        existingDependente.DataNascimento = dependente.DataNascimento;
        existingDependente.GrauParentesco = dependente.GrauParentesco;
        existingDependente.FuncionarioId = dependente.FuncionarioId; // Atualize o ID do funcionário, se necessário

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteDependente(long id)
    {
        var dependente = _context.Dependentes.FirstOrDefault(d => d.Id == id);

        if (dependente == null)
        {
            throw new InvalidOperationException($"Dependente com ID {id} não encontrado.");
        }

        _context.Dependentes.Remove(dependente);
        _context.SaveChanges();
    }
}
