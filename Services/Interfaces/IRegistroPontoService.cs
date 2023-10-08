using System.Collections.Generic;
using sistemaFolhaDePagamento.DTOS;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.Service
{
    public interface IRegistroPontoService
    {
        IEnumerable<RegistroPonto> GetRegistrosPonto();
        RegistroPonto GetRegistroPontoById(int id);
        void CreateRegistroPonto(RegistroPonto registroPonto);
        void UpdateRegistroPonto(int id, RegistroPonto RegistroPontos);
        void DeleteRegistroPonto(int id);
        FuncionarioCargo RegistrarPonto(LoginDto login);

    }
}