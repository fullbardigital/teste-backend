using FullBarDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FullBarDigital.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class, IEntidadeBase, new()
    {
        IQueryable<TEntity> Queryable();

        IList<TEntity> Listar();

        IList<TEntity> Listar(params Expression<Func<TEntity, object>>[] incluirPropriedades);

        IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao);

        IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao, params Expression<Func<TEntity, object>>[] incluirPropriedades);

        TEntity ObterPorCodigo(int codigo);

        bool ExistePorExpressao(Func<TEntity, bool> expressao);

        void DeletarPorCodigo(int codigo);

        void InserirOuAlterar(TEntity entidade);

        void SalvarAlteracoes();
    }
}