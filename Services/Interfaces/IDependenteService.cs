using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface IDependenteService{
    IEnumerable<Dependente> GetDependentes();
    Dependente GetDependenteById(long id);
    void CreateDependente(Dependente dependente);
    void UpdateDependente(long id, Dependente dependente);
    void DeleteDependente(long id);
}}