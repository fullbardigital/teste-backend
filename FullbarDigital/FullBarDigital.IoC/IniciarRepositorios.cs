using FullBarDigital.Dominio.Interfaces.Repositorios;
using FullBarDigital.Infraestrutura.Contextos;
using FullBarDigital.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FullBarDigital.IoC
{
    public class IniciarRepositorios
    {
        public static void Iniciar(IServiceCollection servicos)
        {
            servicos.AddScoped<DbContext, Contexto>();
            servicos.AddScoped<IRepositorioAluno, RepositorioAluno>();
            servicos.AddScoped<IRepositorioCurso, RepositorioCurso>();
            servicos.AddScoped<IRepositorioPeriodo, RepositorioPeriodo>();
        }
    }
}