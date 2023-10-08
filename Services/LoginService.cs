using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Services;

namespace sistemaFolhaDePagamento.Services
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public LoginService(ApplicationDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public string AuthenticateAsync(string usuario, string senha)
        {
            // Tente encontrar um login com o nome de usuário fornecido
            var login = _dbContext.Logins
                .Include(l => l.Funcionario)
                .Include(l => l.Empresa)
                .FirstOrDefault(l => l.Usuario == usuario);

            if (login == null || !VerifyPassword(login.Senha, senha))
            {
                // Se o login não for encontrado ou a senha não coincidir, retorne um resultado de autenticação inválida.
                return "{error: \"Nao foi possível fazer!\" }";
            }

            // Se a autenticação for bem-sucedida, retorne os dados do funcionário e da empresa relacionados ao login.
            var token = _tokenService.GenerateToken(
            new LoginResult
            {
                Usuario = usuario,
                Perfil = "",

                IsAuthenticated = true,
                Funcionario = login.Funcionario,
                Empresa = login.Empresa
            });
            return token;
        }

        async Task<string> ILoginService.AuthenticateAsync(string usuario, string senha)
        {
            var query = _dbContext.Logins
                .Include(l => l.Funcionario)
                    .ThenInclude(f => f.FuncionariosCargos)
                        .ThenInclude(fc => fc.RegistroPontos)
                .Include(l => l.Empresa)
                .Where(l => l.Usuario == usuario);

            var login = await query.FirstOrDefaultAsync();

            if (login != null && login.Funcionario != null)
            {
                if (login.Funcionario.FuncionariosCargos == null || !login.Funcionario.FuncionariosCargos.Any(fc => fc.Atual == 1))
                {
                    login.Funcionario.FuncionariosCargos = new List<FuncionarioCargo>();
                }
                else
                {
                    login.Funcionario.FuncionariosCargos = login.Funcionario.FuncionariosCargos
                        .Where(fc => fc.Atual == 1)
                        .ToList();

                    foreach (var fc in login.Funcionario.FuncionariosCargos)
                    {
                        fc.RegistroPontos ??= new List<RegistroPonto>();
                        fc.RegistroPontos = fc.RegistroPontos.ToList();
                    }
                }
            }




            if (login == null || !VerifyPassword(login.Senha, senha))
            {
                // Se o login não for encontrado ou a senha não coincidir, retorne uma string vazia.
                return  "{\"error\":\"Credenciais inválidas\"}";
            }

            // Se a autenticação for bem-sucedida, retorne um token JWT como uma string.
            var token = _tokenService.GenerateToken(
                new LoginResult
                {
                    Usuario = usuario,
                    Perfil = "",
                    IsAuthenticated = true,
                    Funcionario = login.Funcionario,
                    Empresa = login.Empresa,
                }
                 // Adicione as configurações do Newtonsoft.Json aqui
            );

            return  $"{{\"token\":\"{token}\"}}";;
        }

        private bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            // Implemente sua lógica de verificação de senha aqui
            // Compare a senha fornecida com a senha armazenada de forma segura
            // Você pode usar uma biblioteca de hashing segura, como BCrypt ou PBKDF2, para isso.
            // Retorne true se as senhas coincidirem, caso contrário, retorne false.
            // Este é um exemplo simplificado, não seguro:
            return hashedPassword == providedPassword;
        }
    }
}
public class LoginResult
{
    public string Usuario { get; set; }
    public string Perfil { get; set; }
    public bool IsAuthenticated { get; set; }
    public Funcionario Funcionario { get; set; }
    public Empresa Empresa { get; set; }
}


