using System;
using System.Collections.Generic;
using System.Linq;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;

public class CargoService  : sistemaFolhaDePagamento.Service.ICargoService
{
    private readonly ApplicationDbContext _context;

    public CargoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cargo> GetCargos()
    {
        return _context.Cargos.ToList();
    }

    public Cargo GetCargoById(long id)
    {
        return _context.Cargos.FirstOrDefault(c => c.Id == id);
    }

    public void CreateCargo(Cargo cargo)
    {
        if (cargo == null)
        {
            throw new ArgumentNullException(nameof(cargo));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(cargo);
    }

    public void UpdateCargo(long id, Cargo cargo)
    {
        if (cargo == null)
        {
            throw new ArgumentNullException(nameof(cargo));
        }

        var existingCargo = _context.Cargos.FirstOrDefault(c => c.Id == id);

        if (existingCargo == null)
        {
            throw new InvalidOperationException($"Cargo com ID {id} não encontrado.");
        }

        // Atualize as propriedades do cargo existente com as propriedades do novo cargo
        existingCargo.Nome = cargo.Nome;
        existingCargo.JornadaTrabalhoHoras = cargo.JornadaTrabalhoHoras;
        existingCargo.SalarioMensal = cargo.SalarioMensal;
        existingCargo.SalarioHora = cargo.SalarioHora;
        existingCargo.DepartamentoId = cargo.DepartamentoId; // Atualize o ID do departamento, se necessário

        // Lembre-se de que, se você quiser atualizar outras propriedades, também deve fazê-lo aqui.

        _context.SaveChanges();
    }

    public void DeleteCargo(long id)
    {
        var cargo = _context.Cargos.FirstOrDefault(c => c.Id == id);

        if (cargo == null)
        {
            throw new InvalidOperationException($"Cargo com ID {id} não encontrado.");
        }

        _context.Cargos.Remove(cargo);
        _context.SaveChanges();
    }
}
