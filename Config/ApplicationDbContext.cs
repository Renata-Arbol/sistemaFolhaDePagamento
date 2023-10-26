using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.Models;

namespace sistemaFolhaDePagamento.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<FuncionarioCargo> FuncionariosCargos { get; set; }
        public DbSet<RegistroPonto> RegistroPontos { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<TabelaINSS> TabelaINSS { get; set; }
        
        public DbSet<TabelaIR> TabelaIR { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Documento>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Dependente>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Contato>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Empresa>()
                .HasKey(e => e.Id);


            modelBuilder.Entity<Cargo>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Login>()
                .ToTable("Logins"); // Define o nome da tabela como "Logins"

            /**

                        modelBuilder.Entity<FuncionarioCargo>()
                            .HasKey(fc => new { fc.FuncionarioId, fc.CargoId });
*/
            modelBuilder.Entity<FuncionarioCargo>()
                .HasKey(fc => fc.Id);

            modelBuilder.Entity<RegistroPonto>()
                .HasKey(rp => rp.Id); // Defina a chave primária



            // Definindo relacionamentos

            modelBuilder.Entity<Funcionario>()
                .HasMany(f => f.Contatos) // Funcionario possui muitos Contatos
                .WithOne(c => c.Funcionario) // Contato pertence a um Funcionario
                .HasForeignKey(c => c.FuncionarioId); // Chave estrangeira em Contato

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Documento)
                .WithMany()
                .HasForeignKey(f => f.DocumentoId)
                .HasConstraintName("FK_Funcionarios_DocumentoId");

            modelBuilder.Entity<FuncionarioCargo>()
                .HasOne(fc => fc.Funcionario)
                .WithMany(f => f.FuncionariosCargos)
                .HasForeignKey(fc => fc.FuncionarioId);

            modelBuilder.Entity<FuncionarioCargo>()
                .HasOne(fc => fc.Cargo)
                .WithMany(c => c.FuncionariosCargos)
                .HasForeignKey(fc => fc.CargoId);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Empresa)
                .WithMany(emp => emp.Enderecos)
                .HasForeignKey(e => e.EmpresaId);

            modelBuilder.Entity<RegistroPonto>()
                .HasOne(rp => rp.FuncionarioCargo)
                .WithMany(fc => fc.RegistroPontos)
                .HasForeignKey(rp => rp.FuncionarioCargoId);



            modelBuilder.Entity<Login>()
                .HasOne(l => l.Funcionario) // Um Login pertence a uma Empresa
                .WithOne(e => e.Login) // Uma Empresa pode ter vários Logins
                .HasForeignKey<Login>(l => l.FuncionarioId) 
                .HasConstraintName("FK_Funcionarios_Login");
                
            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Empresa)
                .WithMany()
                .HasForeignKey(f => f.EmpresaId)
                .HasConstraintName("FK_Funcionarios_Empresa")
                .IsRequired();
        }
    }
}

