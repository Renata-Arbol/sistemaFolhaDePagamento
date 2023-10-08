using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using sistemaFolhaDePagamento.Models;

public class EnderecoService  : sistemaFolhaDePagamento.Service.IEnderecoService
{
    private readonly ApplicationDbContext _context;

    public EnderecoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Endereco> GetEnderecos()
    {
        return _context.Enderecos.ToList();
    }

    public Endereco GetEnderecoById(long id)
    {
        return _context.Enderecos.FirstOrDefault(e => e.Id == id);
    }

    public void CreateEndereco(Endereco endereco)
    {
        if (endereco == null)
        {
            throw new ArgumentNullException(nameof(endereco));
        }
        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(endereco);
    }

    public void UpdateEndereco(long id, Endereco endereco)
    {
        if (endereco == null)
        {
            throw new ArgumentNullException(nameof(endereco));
        }

        var existingEndereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

        if (existingEndereco == null)
        {
            throw new InvalidOperationException($"Endereco com ID {id} não encontrado.");
        }

        // Atualize as propriedades do endereco existente com as propriedades do novo endereco
        existingEndereco.Rua = endereco.Rua;
        existingEndereco.Numero = endereco.Numero;
        existingEndereco.Complemento = endereco.Complemento;
        existingEndereco.Bairro = endereco.Bairro;
        existingEndereco.Cidade = endereco.Cidade;
        existingEndereco.Estado = endereco.Estado;
        existingEndereco.CEP = endereco.CEP;
        existingEndereco.EmpresaId = endereco.EmpresaId; // Atualize o ID da empresa, se necessário

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteEndereco(long id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

        if (endereco == null)
        {
            throw new InvalidOperationException($"Endereco com ID {id} não encontrado.");
        }

        _context.Enderecos.Remove(endereco);
        _context.SaveChanges();
    }
}
