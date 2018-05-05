using Doodor.OrganizadorPessoal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Doodor.OrganizadorPessoal.Domain.Repository
{
    public interface IRepositoryBaseSqlServer<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity FindById(Guid id);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        ICollection<TEntity> FindAll();
        
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);

        int SaveChanges();
    }
}
