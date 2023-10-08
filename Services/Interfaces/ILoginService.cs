using System.Threading.Tasks;

namespace sistemaFolhaDePagamento.Services
{
    public interface ILoginService
    {
        Task<string> AuthenticateAsync(string usuario, string senha);
    }
}
