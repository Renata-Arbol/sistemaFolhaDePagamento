using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;
namespace sistemaFolhaDePagamento.Service{
public interface ITipoEmailService
{
    
    IEnumerable<TipoEmail> GetTiposEmail();
    TipoEmail GetTipoEmailById(int id);
    void CreateTipoEmail(TipoEmail tipoEmail);
    void UpdateTipoEmail(int id, TipoEmail tipoEmail);
    void DeleteTipoEmail(int id);
}}