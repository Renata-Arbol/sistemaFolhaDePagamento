using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;

public class EmpresaService  : sistemaFolhaDePagamento.Service.IEmpresaService
{
    private readonly ApplicationDbContext _context;

    public EmpresaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Empresa> GetEmpresas()
    {
        return _context.Empresas.ToList();
    }

    public Empresa GetEmpresaById(long id)
    {
        return _context.Empresas.FirstOrDefault(e => e.Id == id);
    }

    public void CreateEmpresa(Empresa empresa)
    {
        if (empresa == null)
        {
            throw new ArgumentNullException(nameof(empresa));
        }
        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(empresa);
    }

    public void UpdateEmpresa(long id, Empresa empresa)
    {
        var existingEmpresa = _context.Empresas.FirstOrDefault(e => e.Id == id);

        if (existingEmpresa == null)
        {
            throw new InvalidOperationException($"Empresa com ID {id} não encontrada.");
        }

        // Atualize as propriedades da empresa existente com as propriedades da nova empresa
        existingEmpresa.RazaoSocial = empresa.RazaoSocial;
        existingEmpresa.Telefone = empresa.Telefone;

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteEmpresa(long id)
    {
        var empresa = _context.Empresas.FirstOrDefault(e => e.Id == id);

        if (empresa == null)
        {
            throw new InvalidOperationException($"Empresa com ID {id} não encontrada.");
        }

        _context.Empresas.Remove(empresa);
        _context.SaveChanges();
    }
}
