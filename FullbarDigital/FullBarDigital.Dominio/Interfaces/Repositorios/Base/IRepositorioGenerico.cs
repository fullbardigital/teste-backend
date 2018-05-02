using System;
using System.Collections.Generic;
using System.Linq;

namespace FullBarDigital.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioGenerico<TEntity> : IDisposable where TEntity : class, new()
    {
        IQueryable<TEntity> Queryable();

        List<TEntity> Listar();

        List<TEntity> ListarPorExpressao(Func<TEntity, bool> expression);

        TEntity ObterPorCodigo(int codigo);

        bool ExistePorExpressao(Func<TEntity, bool> expressao);

        void SalvarAlteracoes();

        void DeletarPorExpressao(Func<TEntity, bool> expressao);

        void Inserir(TEntity entidade);
    }
}