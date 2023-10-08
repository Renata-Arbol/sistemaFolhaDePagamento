using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface IFuncionarioService
{
    IEnumerable<Funcionario> GetFuncionarios();
    Funcionario GetFuncionarioById(long id);
    void CreateFuncionario(Funcionario funcionario);
    void UpdateFuncionario(long id, Funcionario funcionario);
    void DeleteFuncionario(long id);
}
}