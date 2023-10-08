using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface IDocumentoService
{
    IEnumerable<Documento> GetDocumentos();
    Documento GetDocumentoById(long id);
    void CreateDocumento(Documento documento);
    void UpdateDocumento(long id, Documento documento);
    void DeleteDocumento(long id);
}
}