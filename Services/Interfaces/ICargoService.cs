using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.Service{
    public interface ICargoService
{
    IEnumerable<Cargo> GetCargos();
    Cargo GetCargoById(long id);
    void CreateCargo(Cargo cargo);
    void UpdateCargo(long id, Cargo cargo);
    void DeleteCargo(long id);
}
}