using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using sistemaFolhaDePagamento.Models;

public class TipoEmailService  : sistemaFolhaDePagamento.Service.ITipoEmailService
{
    private readonly ApplicationDbContext _context;

    public TipoEmailService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TipoEmail> GetTiposEmail()
    {
        return _context.TiposEmail.ToList();
    }

    public TipoEmail GetTipoEmailById(int id)
    {
        return _context.TiposEmail.FirstOrDefault(te => te.Id == id);
    }

    public void CreateTipoEmail(TipoEmail tipoEmail)
    {
        if (tipoEmail == null)
        {
            throw new ArgumentNullException(nameof(tipoEmail));
        }


        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(tipoEmail);
    }

    public void UpdateTipoEmail(int id, TipoEmail tipoEmail)
    {
        if (tipoEmail == null)
        {
            throw new ArgumentNullException(nameof(tipoEmail));
        }

        var existingTipoEmail = _context.TiposEmail.FirstOrDefault(te => te.Id == id);

        if (existingTipoEmail == null)
        {
            throw new InvalidOperationException($"TipoEmail com ID {id} não encontrado.");
        }

        // Atualize as propriedades do tipo de email existente com as propriedades do novo tipo de email
        existingTipoEmail.Nome = tipoEmail.Nome;
        // Adicione aqui quaisquer outras propriedades que deseja atualizar.

        _context.SaveChanges();
    }

    public void DeleteTipoEmail(int id)
    {
        var tipoEmail = _context.TiposEmail.FirstOrDefault(te => te.Id == id);

        if (tipoEmail == null)
        {
            throw new InvalidOperationException($"TipoEmail com ID {id} não encontrado.");
        }

        _context.TiposEmail.Remove(tipoEmail);
        _context.SaveChanges();
    }
}
