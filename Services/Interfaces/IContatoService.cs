using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
    public interface IContatoService
{
    IEnumerable<Contato> GetContatos();
    Contato GetContatoById(long id);
    void CreateContato(Contato contato);
    void UpdateContato(long id, Contato contato);
    void DeleteContato(long id);
}}