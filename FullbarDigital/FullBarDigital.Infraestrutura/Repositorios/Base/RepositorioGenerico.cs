using FullBarDigital.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullBarDigital.Infraestrutura.Repositorios.Base
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class, new()
    {
        public DbContext Contexto;

        public RepositorioGenerico() { }

        public RepositorioGenerico(DbContext contexto)
        {
            Contexto = contexto;
        }

        ~RepositorioGenerico()
        {
            Dispose(false);
        }

        private DbSet<TEntity> Entidade()
        {
            return Contexto.Set<TEntity>();
        }

        public void DeletarPorExpressao(Func<TEntity, bool> expressao)
        {
            if (!ExistePorExpressao(expressao)) return;

            Entidade().RemoveRange(Entidade().Where(expressao));
        }

        public bool ExistePorExpressao(Func<TEntity, bool> expressao)
        {
            return Entidade().AsNoTracking().Any(expressao);
        }

        public void Inserir(TEntity entidade)
        {
            Entidade().Add(entidade);
        }

        public List<TEntity> Listar()
        {
            return Entidade().AsNoTracking().Any() ? Entidade().AsNoTracking().ToList() : null;
        }

        public List<TEntity> ListarPorExpressao(Func<TEntity, bool> expression)
        {
            return Entidade().AsNoTracking().Any(expression) ? Entidade().AsNoTracking().Where(expression).ToList() : null;
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
    }
}