using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace sistemaFolhaDePagamento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); // Verifique se o UseStartup aponta para sua classe Startup
                });
    }
}