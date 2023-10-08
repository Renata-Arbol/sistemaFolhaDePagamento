using sistemaFolhaDePagamento.Models;
using Microsoft.EntityFrameworkCore;
using sistemaFolhaDePagamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class DepartamentoService  : sistemaFolhaDePagamento.Service.IDepartamentoService
{
    private readonly ApplicationDbContext _context;

    public DepartamentoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Departamento> GetDepartamentos()
    {
        return _context.Departamentos.ToList();
    }

    public Departamento GetDepartamentoById(long id)
    {
        return _context.Departamentos.FirstOrDefault(d => d.Id == id);
    }

    public void CreateDepartamento(Departamento departamento)
    {
        if (departamento == null)
        {
            throw new ArgumentNullException(nameof(departamento));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(departamento);
    }

    public void UpdateDepartamento(long id, Departamento departamento)
    {
        if (departamento == null)
        {
            throw new ArgumentNullException(nameof(departamento));
        }

        var existingDepartamento = _context.Departamentos.FirstOrDefault(d => d.Id == id);

        if (existingDepartamento == null)
        {
            throw new InvalidOperationException($"Departamento com ID {id} não encontrado.");
        }

        // Atualize as propriedades do departamento existente com as propriedades do novo departamento
        existingDepartamento.Nome = departamento.Nome;
        existingDepartamento.Descricao = departamento.Descricao;

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteDepartamento(long id)
    {
        var departamento = _context.Departamentos.FirstOrDefault(d => d.Id == id);

        if (departamento == null)
        {
            throw new InvalidOperationException($"Departamento com ID {id} não encontrado.");
        }

        _context.Departamentos.Remove(departamento);
        _context.SaveChanges();
    }
}
