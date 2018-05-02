using FullBarDigital.Dominio.Dominios;
using FullBarDigital.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FullBarDigital.IoC
{
    public class IniciarDominios
    {
        public static void Iniciar(IServiceCollection servicos)
        {
            servicos.AddScoped<IDominioAluno, DominioAluno>();
            servicos.AddScoped<IDominioCurso, DominioCurso>();
            servicos.AddScoped<IDominioPeriodo, DominioPeriodo>();
        }
    }
}