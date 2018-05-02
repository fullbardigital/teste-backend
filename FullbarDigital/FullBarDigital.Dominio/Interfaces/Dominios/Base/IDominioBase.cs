using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FullBarDigital.Dominio.Interfaces
{
    public interface IDominioBase<TEntity> where TEntity : class
    {
        IList<TEntity> Listar();

        IList<TEntity> Listar(params Expression<Func<TEntity, object>>[] incluirPropriedades);

        IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao);

        IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao, params Expression<Func<TEntity, object>>[] incluirPropriedades);

        TEntity ObterPorCodigo(int codigo);

        bool ExistePorExpressao(Func<TEntity, bool> expressao);

        void DeletarPorCodigo(int codigo);

        void Salvar(TEntity entidade);

        void SalvarAlteracoes();
    }
}