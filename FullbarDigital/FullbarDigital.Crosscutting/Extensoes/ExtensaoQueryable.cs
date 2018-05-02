using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class ExtensaoQueryable
    {
        public static IQueryable<TEntity> IncluirPropriedades<TEntity>(this IQueryable<TEntity> entidades,
          params Expression<Func<TEntity, object>>[] propriedades) where TEntity : class
        {
            if (propriedades != null)
                entidades = propriedades.Aggregate(entidades, (atual, include) => atual.Include(include));

            return entidades;
        }
    }
}