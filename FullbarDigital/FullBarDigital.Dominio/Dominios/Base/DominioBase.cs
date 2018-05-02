using FullBarDigital.Dominio.Entidades;
using FullBarDigital.Dominio.Interfaces;
using FullBarDigital.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FullBarDigital.Dominio.Dominios
{
    public abstract class DominioBase<TEntity> : IDominioBase<TEntity> where TEntity : class, IEntidadeBase, new()
    {
        private readonly IRepositorioBase<TEntity> _repositorioBase;

        public DominioBase(IRepositorioBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        public void DeletarPorCodigo(int codigo)
        {
            _repositorioBase.DeletarPorCodigo(codigo);
        }

        public bool ExistePorExpressao(Func<TEntity, bool> expressao)
        {
            return _repositorioBase.ExistePorExpressao(expressao);
        }

        public IList<TEntity> Listar()
        {
            return _repositorioBase.Listar();
        }

        public IList<TEntity> Listar(params Expression<Func<TEntity, object>>[] incluirPropriedades)
        {
            return _repositorioBase.Listar(incluirPropriedades);
        }

        public IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao)
        {
            return _repositorioBase.ListarPorExpressao(expressao);
        }

        public IList<TEntity> ListarPorExpressao(Func<TEntity, bool> expressao, params Expression<Func<TEntity, object>>[] incluirPropriedades)
        {
            return _repositorioBase.ListarPorExpressao(expressao);
        }

        public TEntity ObterPorCodigo(int codigo)
        {
            return _repositorioBase.ObterPorCodigo(codigo);
        }

        public void Salvar(TEntity entidade)
        {
            _repositorioBase.InserirOuAlterar(entidade);
        }

        public void SalvarAlteracoes()
        {
            _repositorioBase.SalvarAlteracoes();
        }
    }
}