using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Repository;
using Doodor.OrganizadorPessoal.Repo.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Doodor.OrganizadorPessoal.Repo.SqlServer.Repository
{
    public abstract class RepositoryBaseSqlServer<TEntity> : IRepositoryBaseSqlServer<TEntity> where TEntity : Entity
    {
        protected ContasContext Db;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBaseSqlServer(ContasContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }
        
        public virtual TEntity FindById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public virtual ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual ICollection<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            var isDetached = Db.Entry(obj).State == EntityState.Detached;

            if(isDetached)
                Db.Attach<TEntity>(obj);

            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}
