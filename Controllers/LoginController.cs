using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Services; // Substitua pelo namespace correto do seu serviço
using System.Threading.Tasks;

namespace SuaAplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            try
            {
                var funcionario = await _loginService.AuthenticateAsync(login.Usuario, login.Senha);

                if (funcionario == null)
                {
                    return BadRequest($"Erro: Usuário ou senha inválido");
                }

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }
    }
}
