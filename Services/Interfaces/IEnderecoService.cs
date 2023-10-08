using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface IEnderecoService
{
    IEnumerable<Endereco> GetEnderecos();
    Endereco GetEnderecoById(long id);
    void CreateEndereco(Endereco endereco);
    void UpdateEndereco(long id, Endereco endereco);
    void DeleteEndereco(long id);
}}