using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface IEmpresaService
{
    IEnumerable<Empresa> GetEmpresas();
    Empresa GetEmpresaById(long id);
    void CreateEmpresa(Empresa empresa);
    void UpdateEmpresa(long id, Empresa empresa);
    void DeleteEmpresa(long id);
}}