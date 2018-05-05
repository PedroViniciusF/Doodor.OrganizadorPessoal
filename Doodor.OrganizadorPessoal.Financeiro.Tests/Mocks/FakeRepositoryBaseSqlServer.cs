using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks
{
    public class FakeRepositoryBaseSqlServer<TEntity> : IDisposable, IRepositoryBaseSqlServer<TEntity> where TEntity : Entity
    {
        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
