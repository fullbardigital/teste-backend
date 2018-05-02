using FullBarDigital.Dominio.Entidades;
using FullBarDigital.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FullBarDigital.Infraestrutura.Repositorios
{
    public abstract class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class, IEntidadeBase, new()
    {
        #region Propriedades

        public DbContext Contexto;

        #endregion
        
        #region Construtores e Destrutores

        public RepositorioBase() { }

        public RepositorioBase(DbContext contexto)
        {
            Contexto = contexto;
        }

        ~RepositorioBase()
        {
            Dispose(false);
        }

        #endregion

        #region Métodos Privados

        private DbSet<TEntity> Entidade()
        {
            return Contexto.Set<TEntity>();
        }

        #endregion

        #region Métodos Públicos

        public void DeletarPorCodigo(int codigo)
        {
            if (codigo == 0 || !ExistePorExpressao(e => e.Codigo == codigo)) return;

            var contextoDaEntidade = ObterPorCodigo(codigo);
            Contexto.Entry(contextoDaEntidade).State = EntityState.Deleted;
            Entidade().Remove(contextoDaEntidade);
        }

        public bool ExistePorExpressao(Func<TEntity, bool> expressao)
        {
            return Queryable().Any(expressao);
        }

        public void InserirOuAlterar(TEntity entidade)
        {
            var contextoDaEntidade = ObterPorCodigo(entidade.Codigo);

            if (contextoDaEntidade == null)
                Entidade().Add(entidade);
            else
            {
                Contexto.Entry(contextoDaEntidade).CurrentValues.SetValues(entidade);
                Contexto.Entry(contextoDaEntidade).State = EntityState.Modified;
            }
        }

        public IList<TEntity> Listar()
        {
            return Queryable().Any() ? Queryable().ToList() : null;
        }

        public IList<TEntity> Listar(params Expression<Func<TEntity, object>>[] incluirPropriedades)
        {
            return Queryable().Any() ? Queryable().IncluirPropriedades(incluirPropriedades).ToList() : null;
        }

        public IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao)
        {
            return Queryable().Any(expressao) ? Queryable().Where(expressao).ToList() : null;
        }

        public IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao,
            params Expression<Func<TEntity, object>>[] incluirPropriedades)
        {
            return Queryable().Any(expressao)
                ? Queryable().IncluirPropriedades(incluirPropriedades).Where(expressao).ToList()
                : null;
        }

        public TEntity ObterPorCodigo(int codigo)
        {
            return Entidade().Find(codigo);
        }

        public IQueryable<TEntity> Queryable()
        {
            return Entidade().AsQueryable().AsNoTracking();
        }

        public void SalvarAlteracoes()
        {
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || Contexto == null) return;

            Contexto.Dispose();
            Contexto = null;
        } 
        
        #endregion
    }
}