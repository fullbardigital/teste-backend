using Fullbar.API.Repositories;
using Fullbar.API.Repositories.Interfaces;
using Fullbar.API.Services;
using Fullbar.API.Services.Interfaces;
using Fullbar.Core.Repositories;
using Fullbar.Core.Services;
using Fullbar.Core.UnitOfWork;
using Fullbar.Entities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection Add_Fullbar_Interfaces(this IServiceCollection services)
        {
            // Adiciona as interfaces "base" para o projeto
            services.AddScoped<IUnitOfWork, UnitOfWork<DB_TESTEContext>>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<,>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            // Adiciona os repositórios
            services.AddScoped<IAlunoRepository, AlunoRepository>();

            // Cria de forma genérica um repositório que implementa a classe "RepositoryBase"
            services.AddScoped<IRepositoryBase<TbCurso>>(p => new RepositoryBase<TbCurso, DB_TESTEContext>(p.GetService<DB_TESTEContext>()));
            services.AddScoped<IRepositoryBase<TbPeriodo>>(p => new RepositoryBase<TbPeriodo, DB_TESTEContext>(p.GetService<DB_TESTEContext>()));

            // Adiciona os serviços
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IPeriodoService, PeriodoService>();

            return services;
        }
    }
}
