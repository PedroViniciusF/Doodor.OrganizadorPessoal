using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doodor.OrganizadorPessoal.Financeiro.Tests.Mocks
{
    public class FakeRepositoryBaseMongo<TEntity> : IDisposable, IRepositoryBaseMongo<TEntity> where TEntity : Entity
    {
        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void AddMany(List<TEntity> lstObj)
        {
            throw new NotImplementedException();
        }

        public Task AddManyAsync(List<TEntity> lstObj)
        {
            throw new NotImplementedException();
        }

        public bool DbIsConnected()
        {
            throw new NotImplementedException();
        }

        public void DeleteOne(string collectionName, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneAsync(string collectionName, Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DropCollection(string name)
        {
            throw new NotImplementedException();
        }

        public Task DropCollectionAsync(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll(string collectionName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAllAsync(string collectionName)
        {
            throw new NotImplementedException();
        }

        public TEntity FindOne(string collectionName, FilterDefinition<TEntity> filter)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindOneAsync(string collectionName, FilterDefinition<TEntity> filter)
        {
            throw new NotImplementedException();
        }

        public UpdateResult Update(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateResult> UpdateAsync(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateMany(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateResult> UpdateManyAsync(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            throw new NotImplementedException();
        }
    }
}
