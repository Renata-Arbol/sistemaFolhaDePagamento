﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaFolhaDePagamento.Models;

#nullable disable

namespace sistemaFolhaDePagamento.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231014233456_TabelaIR")]
    partial class TabelaIR
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Login", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("FuncionarioId")
                        .IsUnique();

                    b.ToTable("Logins", (string)null);
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Cargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<long?>("DepartamentoId")
                        .HasColumnType("bigint");

                    b.Property<int>("JornadaTrabalhoHoras")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("SalarioHora")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("SalarioMensal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Contato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Departamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Dependente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("GrauParentesco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Dependentes");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Documento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EstadoEmissor")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("OrgaoEmissor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PaisEmissor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<long?>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Funcionario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DocumentoId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmpresaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("EmpresaId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("LoginId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EmpresaId1");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.FuncionarioCargo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<int>("Atual")
                        .HasColumnType("int");

                    b.Property<long?>("CargoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FuncionariosCargos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Pagamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<double>("ValorLiquido")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.RegistroPonto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("auto_id");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("FuncionarioCargoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Observacao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioCargoId");

                    b.ToTable("RegistroPontos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.TabelaINSS", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<decimal>("Aliquota")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("FaixaFinal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("FaixaInicial")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("TabelaINSS");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.TabelaIR", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("auto_id");

                    b.Property<decimal>("Aliquota")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Deducao")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("FaixaFinal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("FaixaInicial")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("TabelaIR");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("auto_id");

                    b.Property<long?>("FuncionarioId")
                        .HasColumnType("bigint");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.TipoEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TiposEmail");
                });

            modelBuilder.Entity("Login", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithOne("Login")
                        .HasForeignKey("Login", "FuncionarioId")
                        .HasConstraintName("FK_Funcionarios_Login");

                    b.Navigation("Empresa");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Cargo", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Departamento", "Departamento")
                        .WithMany("Cargos")
                        .HasForeignKey("DepartamentoId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Contato", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithMany("Contatos")
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Departamento", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Empresa", "Empresa")
                        .WithMany("Departamentos")
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Dependente", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithMany("Dependentes")
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Documento", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Endereco", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Empresa", "Empresa")
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Empresa");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Funcionario", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId")
                        .HasConstraintName("FK_Funcionarios_DocumentoId");

                    b.HasOne("sistemaFolhaDePagamento.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Funcionarios_Empresa");

                    b.HasOne("sistemaFolhaDePagamento.Models.Empresa", null)
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaId1");

                    b.Navigation("Documento");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.FuncionarioCargo", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Cargo", "Cargo")
                        .WithMany("FuncionariosCargos")
                        .HasForeignKey("CargoId");

                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithMany("FuncionariosCargos")
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Cargo");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.RegistroPonto", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.FuncionarioCargo", "FuncionarioCargo")
                        .WithMany("RegistroPontos")
                        .HasForeignKey("FuncionarioCargoId");

                    b.Navigation("FuncionarioCargo");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Telefone", b =>
                {
                    b.HasOne("sistemaFolhaDePagamento.Models.Funcionario", "Funcionario")
                        .WithMany("Telefones")
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Cargo", b =>
                {
                    b.Navigation("FuncionariosCargos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Departamento", b =>
                {
                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Empresa", b =>
                {
                    b.Navigation("Departamentos");

                    b.Navigation("Enderecos");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.Funcionario", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Dependentes");

                    b.Navigation("Enderecos");

                    b.Navigation("FuncionariosCargos");

                    b.Navigation("Login");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("sistemaFolhaDePagamento.Models.FuncionarioCargo", b =>
                {
                    b.Navigation("RegistroPontos");
                });
#pragma warning restore 612, 618
        }
    }
}
