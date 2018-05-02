using FullBarDigital.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullBarDigital.IoC
{
    public class IniciarContexto
    {
        public static void Iniciar(IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddDbContext<Contexto>(opcao =>
            {
                opcao.UseSqlServer(configuracao.GetConnectionString("Contexto"));
            });
        }
    }
}