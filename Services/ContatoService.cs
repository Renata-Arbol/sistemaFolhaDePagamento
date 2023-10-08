using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;

public class ContatoService  : sistemaFolhaDePagamento.Service.IContatoService
{
    private readonly ApplicationDbContext _context;

    public ContatoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Contato> GetContatos()
    {
        return _context.Contatos.ToList();
    }

    public Contato GetContatoById(long id)
    {
        return _context.Contatos.FirstOrDefault(c => c.Id == id);
    }

    public void CreateContato(Contato contato)
    {
        if (contato == null)
        {
            throw new ArgumentNullException(nameof(contato));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(contato);
    }

    public void UpdateContato(long id, Contato contato)
    {
        if (contato == null)
        {
            throw new ArgumentNullException(nameof(contato));
        }

        var existingContato = _context.Contatos.FirstOrDefault(c => c.Id == id);

        if (existingContato == null)
        {
            throw new InvalidOperationException($"Contato com ID {id} não encontrado.");
        }

        // Atualize as propriedades do contato existente com as propriedades do novo contato
        existingContato.Email = contato.Email;
        existingContato.Telefone = contato.Telefone;
        existingContato.FuncionarioId = contato.FuncionarioId; // Atualize o ID do funcionário, se necessário

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteContato(long id)
    {
        var contato = _context.Contatos.FirstOrDefault(c => c.Id == id);

        if (contato == null)
        {
            throw new InvalidOperationException($"Contato com ID {id} não encontrado.");
        }

        _context.Contatos.Remove(contato);
        _context.SaveChanges();
    }
}
