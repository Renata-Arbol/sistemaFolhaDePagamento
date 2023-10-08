using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;
using System.Collections.Generic;
namespace sistemaFolhaDePagamento.Service{
public interface IDepartamentoService
{
    IEnumerable<Departamento> GetDepartamentos();
    Departamento GetDepartamentoById(long id);
    void CreateDepartamento(Departamento departamento);
    void UpdateDepartamento(long id, Departamento departamento);
    void DeleteDepartamento(long id);
}
}