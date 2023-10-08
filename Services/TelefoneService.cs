using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using sistemaFolhaDePagamento.Models;

public class TelefoneService  : sistemaFolhaDePagamento.Service.ITelefoneService
{
    private readonly ApplicationDbContext _context;

    public TelefoneService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Telefone> GetTelefones()
    {
        return _context.Telefones.ToList();
    }

    public Telefone GetTelefoneById(int id)
    {
        return _context.Telefones.FirstOrDefault(t => t.Id == id);
    }

    public void CreateTelefone(Telefone telefone)
    {
        if (telefone == null)
        {
            throw new ArgumentNullException(nameof(telefone));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(telefone);
    }

    public void UpdateTelefone(int id, Telefone telefone)
    {
        if (telefone == null)
        {
            throw new ArgumentNullException(nameof(telefone));
        }

        var existingTelefone = _context.Telefones.FirstOrDefault(t => t.Id == id);

        if (existingTelefone == null)
        {
            throw new InvalidOperationException($"Telefone com ID {id} não encontrado.");
        }

        // Atualize as propriedades do Telefone existente com as propriedades do novo Telefone
        // Certifique-se de atualizar todas as propriedades relevantes aqui.

        _context.SaveChanges();
    }

    public void DeleteTelefone(int id)
    {
        var telefone = _context.Telefones.FirstOrDefault(t => t.Id == id);

        if (telefone == null)
        {
            throw new InvalidOperationException($"Telefone com ID {id} não encontrado.");
        }

        _context.Telefones.Remove(telefone);
        _context.SaveChanges();
    }
}
