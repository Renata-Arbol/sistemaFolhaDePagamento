using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using sistemaFolhaDePagamento.Models;

public class DocumentoService : sistemaFolhaDePagamento.Service.IDocumentoService
{
    private readonly ApplicationDbContext _context;

    public DocumentoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Documento> GetDocumentos()
    {
        return _context.Documentos.ToList();
    }

    public Documento GetDocumentoById(long id)
    {
        return _context.Documentos.FirstOrDefault(d => d.Id == id);
    }

    public void CreateDocumento(Documento documento)
    {
        if (documento == null)
        {
            throw new ArgumentNullException(nameof(documento));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(documento);
    }

    public void UpdateDocumento(long id, Documento documento)
    {
        if (documento == null)
        {
            throw new ArgumentNullException(nameof(documento));
        }

        var existingDocumento = _context.Documentos.FirstOrDefault(d => d.Id == id);

        if (existingDocumento == null)
        {
            throw new InvalidOperationException($"Documento com ID {id} não encontrado.");
        }

        // Atualize as propriedades do documento existente com as propriedades do novo documento
        existingDocumento.RG = documento.RG;
        existingDocumento.CPF = documento.CPF;
        existingDocumento.DataEmissao = documento.DataEmissao;
        existingDocumento.OrgaoEmissor = documento.OrgaoEmissor;
        existingDocumento.EstadoEmissor = documento.EstadoEmissor;
        existingDocumento.PaisEmissor = documento.PaisEmissor;
        existingDocumento.FuncionarioId = documento.FuncionarioId; // Atualize o ID do funcionário, se necessário

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteDocumento(long id)
    {
        var documento = _context.Documentos.FirstOrDefault(d => d.Id == id);

        if (documento == null)
        {
            throw new InvalidOperationException($"Documento com ID {id} não encontrado.");
        }

        _context.Documentos.Remove(documento);
        _context.SaveChanges();
    }
}