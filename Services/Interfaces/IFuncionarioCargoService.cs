using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.Service
{
    public interface IFuncionarioCargoService
    {
        IEnumerable<FuncionarioCargo> GetFuncionarioCargos();
        FuncionarioCargo GetFuncionarioCargoById(int funcionarioCargoId);
        void CreateFuncionarioCargo(FuncionarioCargo funcionarioCargo);
        void UpdateFuncionarioCargo(int funcionarioCargoId, FuncionarioCargo funcionarioCargo);
        void DeleteFuncionarioCargo(int funcionarioCargoId);
        void DeleteFuncionarioCargo(long funcionarioCargoId);
    }
}