using Doodor.OrganizadorPessoal.Domain.Entities;
using Doodor.OrganizadorPessoal.Domain.Repository;
using Doodor.OrganizadorPessoal.Repository.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doodor.OrganizadorPessoal.Repository.Repositories
{
    public class RepositoryBaseMongo<TEntity> : IDisposable, IRepositoryBaseMongo<TEntity> where TEntity : Entity
    {
        protected static IMongoDatabase Db;
        public static MongoContext<TEntity> mongoContext;

        protected IMongoDatabase GetInstance()
        {
            return Db ?? (Db = mongoContext.GetDatabase());
        }

        public bool DbIsConnected()
        {
            return mongoContext.Cluster.Description.State == ClusterState.Connected;
        }

        public void Add(TEntity obj)
        {
            var collection = GetInstance().GetCollection<TEntity>(obj.GetType().Name.ToLower());
            collection.InsertOne(obj);
        }

        public async Task AddAsync(TEntity obj)
        {
            var collection = GetInstance().GetCollection<TEntity>(obj.GetType().Name.ToLower());
            await collection.InsertOneAsync(obj);
        }

        public void AddMany(List<TEntity> lstObj)
        {
            var collection = GetInstance().GetCollection<TEntity>(lstObj.GetType().Name.ToLower());
            collection.InsertMany(lstObj);
        }

        public async Task AddManyAsync(List<TEntity> lstObj)
        {
            var collection = GetInstance().GetCollection<TEntity>(lstObj.GetType().Name.ToLower());
            await collection.InsertManyAsync(lstObj);
        }

        public TEntity FindOne(string collectionName, FilterDefinition<TEntity> filter)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<TEntity> FindOneAsync(string collectionName, FilterDefinition<TEntity> filter)
        {
            return await Task.Run(() =>
            {
                var collection = GetInstance().GetCollection<TEntity>(collectionName);
                return collection.Find(filter).FirstOrDefault();
            });
        }

        public IEnumerable<TEntity> FindAll(string collectionName)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);

            var filter = new BsonDocument();
            return collection.Find(filter).ToCursor().Current;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(string collectionName)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);

            var filter = new BsonDocument();
            using (var cursor = await collection.FindAsync(filter))
            {
                return cursor.Current;
            }
        }     

        public void DeleteOne(string collectionName, Guid id)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            collection.DeleteOne(x => x.Id == id);
        }

        public async Task DeleteOneAsync(string collectionName, Guid id)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            await collection.DeleteOneAsync(x=>x.Id == id);
        }

        public async Task<UpdateResult> UpdateAsync(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            return await collection.UpdateOneAsync(filter, update);
        }

        public async Task<UpdateResult> UpdateManyAsync(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            return await collection.UpdateManyAsync(filter, update);
        }

        public UpdateResult Update(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            return collection.UpdateOne(filter, update);
        }

        public UpdateResult UpdateMany(string collectionName, FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            var collection = GetInstance().GetCollection<TEntity>(collectionName);
            return collection.UpdateMany(filter, update);
        }

        public void DropCollection(string name)
        {
            GetInstance().DropCollection(name);
        }

        public async Task DropCollectionAsync(string name)
        {
            await GetInstance().DropCollectionAsync(name);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db = null;
            }
        }
    }
}
