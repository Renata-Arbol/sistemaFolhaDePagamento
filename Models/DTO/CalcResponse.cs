using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Routing.Internal;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.DTOS
{
public class CalcResponse{

    public CalcResponse(){

    }
    public CalcResponse(string Nome, decimal SalarioMensal, decimal SalarioHora, double Horastrabalhadas, 
    decimal salarioBruto, decimal DescontoINSS, decimal DescontoIR, decimal ParcelaFGTS)
    {
        this.Nome = Nome;
        this.SalarioMensal = SalarioMensal;
        this.Horastrabalhadas = Horastrabalhadas;
        this.SalarioBruto = salarioBruto;
        this.DescontoINSS = DescontoINSS;
        this.DescontoIR = DescontoIR;
        this.ParcelaFGTS = ParcelaFGTS;
    }
    public string Nome { get; set; }

    public long Id { get; set; }
    
    public decimal SalarioMensal { get; set; }

    public decimal SalarioHora { get; set; }

    public double Horastrabalhadas { get; set; }
        
    public decimal SalarioBruto { get; set; }
      
    public decimal DescontoINSS { get; set; }

    public decimal DescontoIR { get; set; }

    public decimal ParcelaFGTS{ get; set; }
   
}
}