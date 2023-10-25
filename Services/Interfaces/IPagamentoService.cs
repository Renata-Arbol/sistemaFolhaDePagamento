using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.DTOS;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface IPagamentoService
{
    IEnumerable<Pagamento> GetPagamentos();
    CalcResponse GetPagamentoById(long id);
    void CreatePagamento(Pagamento pagamento);
    void UpdatePagamento(long id, Pagamento pagamento);
    void DeletePagamento(long id);
}
}