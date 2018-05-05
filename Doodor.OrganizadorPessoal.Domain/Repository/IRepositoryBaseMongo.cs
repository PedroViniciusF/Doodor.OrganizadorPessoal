using Doodor.OrganizadorPessoal.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Doodor.OrganizadorPessoal.Domain.Repository
{
    public interface IRepositoryBaseMongo <TEntity> : IDisposable where TEntity : Entity
    {
        bool DbIsConnected();
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);

        void AddMany(List<TEntity> lstObj);
        Task AddManyAsync(List<TEntity> lstObj);

        TEntity FindOne(string collectionName, FilterDefinition<TEntity> filter);
        Task<TEntity> FindOneAsync(string collectionName, FilterDefinition<TEntity> filter);        

        IEnumerable<TEntity> FindAll(string collectionName);        
        Task<IEnumerable<TEntity>> FindAllAsync(string collectionName);
               
        UpdateResult Update(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
        Task<UpdateResult> UpdateAsync(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);

        UpdateResult UpdateMany(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
        Task<UpdateResult> UpdateManyAsync(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);

        void DeleteOne(string collectionName, Guid id);
        Task DeleteOneAsync(string collectionName, Guid id);

        void DropCollection(string name);        
        Task DropCollectionAsync(string name);                   
    }
}
