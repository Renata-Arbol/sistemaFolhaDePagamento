using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.DTOS;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using sistemaFolhaDePagamento.Models;

public class RegistroPontoService : sistemaFolhaDePagamento.Service.IRegistroPontoService
{
    private readonly ApplicationDbContext _context;

    public RegistroPontoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<RegistroPonto> GetRegistrosPonto()
    {
        return _context.RegistroPontos.ToList();
    }

    public RegistroPonto GetRegistroPontoById(int id)
    {
        return _context.RegistroPontos.FirstOrDefault(rp => rp.Id == id);
    }

    public void CreateRegistroPonto(RegistroPonto registroPonto)
    {
        if (registroPonto == null)
        {
            throw new ArgumentNullException(nameof(registroPonto));
        }
        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(registroPonto);
    }

    public void UpdateRegistroPonto(int id, RegistroPonto registroPonto)
    {
        if (registroPonto == null)
        {
            throw new ArgumentNullException(nameof(registroPonto));
        }

        var existingRegistroPonto = _context.RegistroPontos.FirstOrDefault(rp => rp.Id == id);

        if (existingRegistroPonto == null)
        {
            throw new InvalidOperationException($"RegistroPonto com ID {id} não encontrado.");
        }

        // Atualize as propriedades do RegistroPonto existente com as propriedades do novo RegistroPonto
        // Certifique-se de atualizar todas as propriedades relevantes aqui.

        _context.SaveChanges();
    }


    public FuncionarioCargo RegistrarPonto(LoginDto login)
    {
        var funcionario = _context.Logins
            .Where(l => l.Usuario == login.Usuario && l.Senha == login.Senha)
            .Select(l => l.Funcionario)
            .FirstOrDefault();

        if (funcionario == null)
            throw new Exception("Funcionário não encontrado.");

        var funcionarioCargo = _context.FuncionariosCargos
            .Where(fc => fc.FuncionarioId == funcionario.Id && fc.Atual == 1)
            .FirstOrDefault();

        if (funcionarioCargo == null)
            throw new Exception("Cargo ativo não encontrado para o funcionário.");

        var registroPonto = new RegistroPonto
        {
            DataHora = DateTime.Now,
            Tipo = "entrada",
            FuncionarioCargoId = funcionarioCargo.Id
        };

        _context.RegistroPontos.Add(registroPonto);
        _context.SaveChanges();

        return funcionarioCargo;
    }

    public void DeleteRegistroPonto(int id)
    {
        var RegistroPontos = _context.RegistroPontos.FirstOrDefault(rp => rp.Id == id);

        if (RegistroPontos == null)
        {
            throw new InvalidOperationException($"RegistroPonto com ID {id} não encontrado.");
        }

        _context.RegistroPontos.Remove(RegistroPontos);
        _context.SaveChanges();
    }
}
