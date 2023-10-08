using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace sistemaFolhaDePagamento
{
    public class Startup
    {
        private Empresa? empresasave;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=localhost;Database=sistemafolhadepagamento;User=root;Password=nometoken;";
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
                services.AddControllers().AddJsonOptions(options =>{
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    });
    services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
            // Configurar autenticação JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"], // Configure com suas próprias configurações
                    ValidAudience = Configuration["Jwt:Audience"], // Configure com suas próprias configurações
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])) // Configure com suas próprias configurações
                };
            });

            // Adicionar outros serviços conforme necessário
            services.AddScoped<IDocumentoService, DocumentoService>();
            services.AddScoped<IDependenteService, DependenteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IFuncionarioCargoService, FuncionarioCargoService>();
            services.AddScoped<ITipoEmailService, TipoEmailService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IRegistroPontoService, RegistroPontoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddSingleton<ITokenService>(provider =>
   {
       var configuration = provider.GetRequiredService<IConfiguration>();
       var secretKey = configuration["Jwt:Key"];
       var issuer = configuration["Jwt:Issuer"];
       var audience = configuration["Jwt:Audience"];
       return new TokenService(secretKey, issuer, audience);
   });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nome da sua API", Version = "v1" });
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da Sua API V1");
});
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseEndpoints(endpoints =>
                   {
                       endpoints.MapControllers();
                   });

            // Ativar autenticação e autorização
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da sua API V1");
            });

            // Criar um escopo de serviço para obter o ApplicationDbContext
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Verifique se o banco de dados já foi criado
                // Verifique se o banco de dados já foi criado
                dbContext.Database.Migrate();

                // Verifique se já existem empresas no banco de dados
                if (!dbContext.Empresas.Any())
                {
                    var empresa = new Empresa
                    {
                        Nome = "Minha Empresa",
                        Cnpj = "12345678901234",
                        RazaoSocial = "Razão Social da Minha Empresa",
                        Telefone = "111-111-1111",
                        Enderecos = new List<Endereco>
    {
        new Endereco
        {
            Rua = "Rua A",
            Numero = "123",
            Bairro = "Bairro A",
            Cidade = "Cidade A",
            Estado = "SP",
            CEP = "12345678"
        }
    },
                        Departamentos = new List<Departamento>
    {
        new Departamento
        {
            Nome = "Departamento A",
            Descricao = " Desc",
            Cargos = new List<Cargo>
            {
                new Cargo
                {
                    Nome = "Cargo A1",
                    // Outros campos do Cargo
                }
            }
            // Outros campos do Departamento
        }
    },
                        Funcionarios = new List<Funcionario>
    {

    }
                        // Outros campos da Empresa
                    };

                    dbContext.Empresas.Add(empresa);
                    dbContext.SaveChanges();
                    empresasave = dbContext.Empresas.FirstOrDefault();
                    var funcionario = new Funcionario
                    {
                        Nome = "João Funcionário",
                        DataNascimento = new DateTime(1990, 5, 15),
                        Empresa = empresasave,
                        EmpresaId = empresa.Id,

                        Telefones = new List<Telefone>
    {
        new Telefone
        {
            Tipo =  "Celular",
            Numero = "98765-4321"
        },
        new Telefone
        {
            Tipo =   "Residencial",
            Numero = "1234-5678"
        }
    },
                        Documento = new Documento
                        {
                            RG = "123456789",
                            CPF = "98765432109",
                            DataNascimento = new DateTime(1990, 5, 15),
                            DataEmissao = new DateTime(2000, 1, 1),
                            OrgaoEmissor = "SSP",
                            EstadoEmissor = "SP",
                            PaisEmissor = "Brasil",
                            Sexo = "Masculino"
                        }
                    };

                    var funcionario2 = new Funcionario
                    {
                        Nome = "João Funcionário",
                        DataNascimento = new DateTime(1990, 5, 15),
                        Empresa = empresa,
                        EmpresaId = empresa.Id,
                        Contatos = new List<Contato> {
                 new Contato
                 {
                    Email = "joao.contato@example.com",
                    Telefone = "(11) 98765-4321",
                }
            },
                        Enderecos = new List<Endereco>
    {
        new Endereco
        {
            Rua = "Rua A",
            Numero = "123",
            Bairro = "Bairro A",
            Cidade = "Cidade A",
            Estado = "SP",
            CEP = "12345678"
        }
    },

                        Telefones = new List<Telefone>
    {
        new Telefone
        {
            Tipo = "Celular",
            Numero = "98765-4321"
        },
        new Telefone
        {
            Tipo = "Residencial",
            Numero = "1234-5678"
        }
    },
                        Login = new Login
                        {
                            Usuario = "usuario1",
                            Senha = "usuario1",
                            Empresa = empresasave,
                            EmpresaId = empresasave.Id


                            // Outros campos do Login
                        },
                        Documento = new Documento
                        {
                            RG = "123456789",
                            CPF = "98765432109",
                            DataNascimento = new DateTime(1990, 5, 15),
                            DataEmissao = new DateTime(2000, 1, 1),
                            OrgaoEmissor = "SSP",
                            EstadoEmissor = "SP",
                            PaisEmissor = "Brasil",
                            Sexo = "Masculino"
                        },
                        Dependentes = new List<Dependente>
    {
        new Dependente
        {
            Nome = "Maria Dependente",
            DataNascimento = new DateTime(2005, 2, 10),
            GrauParentesco = "Filha"
        },
        new Dependente
        {
            Nome = "Pedro Dependente",
            DataNascimento = new DateTime(2010, 8, 25),
            GrauParentesco = "Filho"
        }
    },
                        FuncionariosCargos = new List<FuncionarioCargo>{
        new FuncionarioCargo{
            Funcionario = funcionario,
            Atual = 1,
            Cargo = new Cargo
        {
            Nome = "Analista de TI",
            // Outros campos do Cargo
        },
            DataInicio = new DateTime(2020, 1, 1),
            DataFim = new DateTime(2021, 12, 31),
            RegistroPontos = new List<RegistroPonto>{
        new RegistroPonto
            {
                DataHora = DateTime.Now,
                Tipo = "Entrada",
                Observacao = "ok"
            }
        }
}
    }

                    };
                    dbContext.Funcionarios.Add(funcionario);
                    dbContext.Funcionarios.Add(funcionario2);
                    dbContext.Funcionarios.Add(funcionario);
                    dbContext.SaveChanges();
                    var funcionarioCargo = dbContext.FuncionariosCargos.FirstOrDefault();

                    if (funcionarioCargo != null)
                    {
                        // Crie um registro de ponto para o FuncionarioCargo
                        var registroPonto = new RegistroPonto
                        {
                            FuncionarioCargoId = funcionarioCargo.Id,
                            FuncionarioCargo = funcionarioCargo,
                            DataHora = DateTime.Now,
                            Tipo = "Entrada" // Ou "Saída", dependendo do tipo de registro
                        };

                        // Adicione e salve o registro de ponto no DbContext
                        dbContext.RegistroPontos.Add(registroPonto);
                        dbContext.SaveChanges();
                    }
                }

            }

        }
    }
}
