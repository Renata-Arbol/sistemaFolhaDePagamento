using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Routing.Internal;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using sistemaFolhaDePagamento.DTOS;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Models;

public class PagamentoService : sistemaFolhaDePagamento.Service.IPagamentoService
{
    private readonly ApplicationDbContext _context;

    public PagamentoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Pagamento> GetPagamentos()
    {
        return _context.Pagamentos.ToList();
    }

    public CalcResponse GetPagamentoById(long id)
    {

        int ano = 2023;
        int mes = 10;
        var primeiroDiaDoMes = new DateTime(ano, mes, 1);
        var ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1);

        var registrosPonto = _context.RegistroPontos
        .Where(rp => rp.FuncionarioCargo.FuncionarioId == id && rp.DataHora >= primeiroDiaDoMes && rp.DataHora <= ultimoDiaDoMes)
        .OrderBy(rp => rp.DataHora)
        .ToList();
        double horasTrabalhadasNoMes = 0;
        DateTime? entrada = null;
        DateTime? saida = null;

        foreach (var registro in registrosPonto)
        {
            if (registro.Tipo == "entrada")
            {
                entrada = registro.DataHora;
            }
            else if (registro.Tipo == "saida")
            {
                saida = registro.DataHora;

                if (entrada.HasValue && saida.HasValue)
                {
                    horasTrabalhadasNoMes += (saida.Value - entrada.Value).TotalHours;
                    entrada = null;
                    saida = null;
                }
            }
        }

        Console.WriteLine($"Ano: {ano}, Mês: {mes}, Horas Trabalhadas: {horasTrabalhadasNoMes} horas");

        var cargoAtual = _context.Cargos
                .Include(fc => fc.FuncionariosCargos)
                .Where(fc => fc.FuncionariosCargos.Where(
                    fcid => fcid.FuncionarioId == id).FirstOrDefault().CargoId == fc.Id
                )
                .FirstOrDefault();

        Console.WriteLine($"Horas de Jornada Trabalho: {cargoAtual.JornadaTrabalhoHoras}, Salario Hora: {cargoAtual.SalarioHora}, Salario Mensal: {cargoAtual.SalarioMensal}");

        var salarioBruto = (decimal)horasTrabalhadasNoMes * cargoAtual.SalarioHora;
        TabelaINSS aliquotaInss = _context.TabelaINSS.Where(tinss => tinss.FaixaInicial <= salarioBruto).OrderByDescending(o => o.FaixaInicial).FirstOrDefault();

        Console.WriteLine($"salarioBruto: {salarioBruto}");

        Console.WriteLine($"aliquota inss: {aliquotaInss.Aliquota}");

        var salarioBrutoDescINSS = salarioBruto - (salarioBruto * (aliquotaInss.Aliquota / 100));

        Console.WriteLine($"SalarioBrutoDescINSS: {salarioBrutoDescINSS}");

        TabelaIR aliquotaIr = _context.TabelaIR.Where(tir => tir.FaixaInicial <= salarioBrutoDescINSS).OrderByDescending(o => o.FaixaInicial).FirstOrDefault();

        Console.WriteLine($"aliquota ir: {aliquotaIr.Aliquota} deducao: {aliquotaIr.Deducao}");

        var salarioLiquido = (salarioBrutoDescINSS - (salarioBrutoDescINSS * (aliquotaIr.Aliquota / 100))) + aliquotaIr.Deducao;

        Console.WriteLine($"salarioLiquido: {salarioLiquido}");

        var parcelaFGTS = salarioBruto * (decimal)0.08;

        Console.WriteLine($"Parcela FGTS: {parcelaFGTS}");

        var funcionarioNome = _context.Funcionarios.Where(f => f.Id == id).FirstOrDefault().Nome;
        /* 

        ClasseNova instanciaDaClasseNova = new ClasseNova();
        instanciaDaClasseNova.salarioLiquido = salarioLiquido;
        faca isso para todos os valores que deve exibir, 
        crie os atributos na classe nova e atribua os valores com as possiblidades acima que ja fez0

        */
        CalcResponse pagamentoFuncionario = new CalcResponse();


        pagamentoFuncionario.Nome = funcionarioNome;
        pagamentoFuncionario.SalarioMensal = cargoAtual.SalarioMensal;
        pagamentoFuncionario.ParcelaFGTS = parcelaFGTS;
        pagamentoFuncionario.Horastrabalhadas = horasTrabalhadasNoMes;
        pagamentoFuncionario.SalarioHora = cargoAtual.SalarioHora;
        pagamentoFuncionario.SalarioBruto = salarioBruto;
        pagamentoFuncionario.DescontoINSS = salarioBruto - salarioBrutoDescINSS;
        pagamentoFuncionario.DescontoIR = salarioBrutoDescINSS - salarioLiquido;

        return pagamentoFuncionario;
    }

    public void CreatePagamento(Pagamento pagamento)
    {
        if (pagamento == null)
        {
            throw new ArgumentNullException(nameof(pagamento));
        }

        var serializer = new GenericJsonSerializer(_context);
        serializer.SerializeAndSave(pagamento);
    }

    public void UpdatePagamento(long id, Pagamento pagamento)
    {
        var existingPagamento = _context.Pagamentos.FirstOrDefault(f => f.Id == id);

        if (existingPagamento == null)
        {
            throw new InvalidOperationException($"Funcionário com ID {id} não encontrado.");
        }

        existingPagamento.ValorLiquido = pagamento.ValorLiquido;

        _context.SaveChanges();
    }

    public void DeletePagamento(long id)
    {
        var pagamento = _context.Pagamentos.FirstOrDefault(f => f.Id == id);

        if (pagamento == null)
        {
            throw new InvalidOperationException($"Funcionário com ID {id} não encontrado.");
        }

        _context.Pagamentos.Remove(pagamento);
        _context.SaveChanges();
    }
}
