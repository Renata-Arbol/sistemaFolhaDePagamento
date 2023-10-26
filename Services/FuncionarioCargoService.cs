using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using sistemaFolhaDePagamento.Models;

public class FuncionarioCargoService : sistemaFolhaDePagamento.Service.IFuncionarioCargoService
{
    private readonly ApplicationDbContext _context;

    public FuncionarioCargoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<FuncionarioCargo> GetFuncionariosCargos()
    {
        return _context.FuncionariosCargos.ToList();
    }

    public FuncionarioCargo GetFuncionarioCargoById(long funcionarioCargoId)
    {
        return _context.FuncionariosCargos.FirstOrDefault(fc => fc.Id == funcionarioCargoId);
    }

    public void CreateFuncionarioCargo(FuncionarioCargo funcionarioCargo)
    {
        if (funcionarioCargo == null)
        {
            throw new ArgumentNullException(nameof(funcionarioCargo));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(funcionarioCargo);
    }

    public void UpdateFuncionarioCargo(long funcionarioId, long cargoId, FuncionarioCargo funcionarioCargo)
    {
        if (funcionarioCargo == null)
        {
            throw new ArgumentNullException(nameof(funcionarioCargo));
        }

        var existingFuncionarioCargo = _context.FuncionariosCargos.FirstOrDefault(fc => fc.FuncionarioId == funcionarioId && fc.CargoId == cargoId);

        if (existingFuncionarioCargo == null)
        {
            throw new InvalidOperationException($"FuncionarioCargo com FuncionarioID {funcionarioId} e CargoID {cargoId} não encontrado.");
        }

        // Atualize as propriedades do FuncionarioCargo existente com as propriedades do novo FuncionarioCargo
        // Certifique-se de atualizar todas as propriedades relevantes aqui.

        _context.SaveChanges();
    }

    public void DeleteFuncionarioCargo(long funcionarioId, long cargoId)
    {
        var funcionarioCargo = _context.FuncionariosCargos.FirstOrDefault(fc => fc.FuncionarioId == funcionarioId && fc.CargoId == cargoId);

        if (funcionarioCargo == null)
        {
            throw new InvalidOperationException($"FuncionarioCargo com FuncionarioID {funcionarioId} e CargoID {cargoId} não encontrado.");
        }

        _context.FuncionariosCargos.Remove(funcionarioCargo);
        _context.SaveChanges();
    }

    public IEnumerable<FuncionarioCargo> GetFuncionarioCargos()
    {
        throw new NotImplementedException();
    }

    public FuncionarioCargo GetFuncionarioCargoById(int funcionarioCargoId)
    {
        throw new NotImplementedException();
    }

    public void UpdateFuncionarioCargo(int funcionarioCargoId, FuncionarioCargo funcionarioCargo)
    {
        throw new NotImplementedException();
    }

    public void DeleteFuncionarioCargo(int funcionarioCargoId)
    {
        throw new NotImplementedException();
    }

    public void DeleteFuncionarioCargo(long funcionarioCargoId)
    {
        throw new NotImplementedException();
    }
}
