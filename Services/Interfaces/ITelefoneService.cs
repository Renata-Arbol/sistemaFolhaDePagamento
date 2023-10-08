using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.Service
{
    public interface ITelefoneService
    {
        IEnumerable<Telefone> GetTelefones();
        Telefone GetTelefoneById(int id);
        void CreateTelefone(Telefone telefone);
        void UpdateTelefone(int id, Telefone telefone);
        void DeleteTelefone(int id);
    }
}