using Doodor.OrganizadorPessoal.Domain.Config;
using Doodor.OrganizadorPessoal.Domain.Financeiro.ValueObjects;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace Doodor.OrganizadorPessoal.Repository.Context
{
    public class MongoContext<TEntity> : MongoClient where TEntity : class
    {
        public readonly DbSettings dbSettings;

        // Conexao MongoDb Cluster
        //private static MongoClientSettings mongoClientSettings(string environment, string databaseMongo, string databaseCluster, string usernameMongo, string passwordMongo, string urlMongo, string portMongo)
        //{
        //    var mongoCredential = MongoCredential.CreateCredential(databaseMongo, usernameMongo, passwordMongo);

        //    if (environment.Equals("cea"))
        //    {
        //        var mongoClientSettings = new MongoClientSettings
        //        {
        //            Servers = new[]
        //            {
        //                new MongoServerAddress(databaseCluster.Split(';')[0], Convert.ToInt32(portMongo)),
        //                new MongoServerAddress(databaseCluster.Split(';')[1], Convert.ToInt32(portMongo)),
        //                new MongoServerAddress(databaseCluster.Split(';')[2], Convert.ToInt32(portMongo)),
        //            },
        //            ConnectionMode = ConnectionMode.Automatic,
        //            ReplicaSetName = "",
        //            Credentials = new[] { mongoCredential }
        //        };

        //        return mongoClientSettings;
        //    }
        //    else
        //    {
        //        var mongoClientSettings = new MongoClientSettings
        //        {
        //            Credentials = new[] { mongoCredential },
        //            Server = new MongoServerAddress(urlMongo, Convert.ToInt32(portMongo))
        //        };

        //        return mongoClientSettings;

        //    }

        //}

        //public MongoContext(IOptions<DbSettings> dbSettings, IOptions<CommonSettings> commonSettings)
        //    : base(mongoClientSettings(
        //        commonSettings.Value.EnvironmentName, dbSettings.Value.DatabaseMongo,
        //        dbSettings.Value.UrlMongoCluster, dbSettings.Value.UsernameMongo,
        //        dbSettings.Value.PasswordMongo, dbSettings.Value.UrlMongo,
        //        dbSettings.Value.PortMongo))
        //{
        //    this.dbSettings = dbSettings.Value;
        //}

        private static MongoClientSettings mongoClientSettings(string databaseMongo, string usernameMongo, string passwordMongo, string urlMongo, string portMongo)
        {
            var mongoCredential = MongoCredential.CreateCredential(databaseMongo, usernameMongo, passwordMongo);

            var mongoClientSettings = new MongoClientSettings
            {
                Credential = mongoCredential,
                Server = new MongoServerAddress(urlMongo, Convert.ToInt32(portMongo))
            };
            return mongoClientSettings;
        }

        public MongoContext(DbSettings dbSettings)
          : base(mongoClientSettings(
              dbSettings.DatabaseMongo, dbSettings.UsernameMongo,
              dbSettings.PasswordMongo, dbSettings.UrlMongo,
              dbSettings.PortMongo))
        {
            this.dbSettings = dbSettings;
        }

        public IMongoDatabase GetDatabase()
        {
            return base.GetDatabase(dbSettings.FirstDatabase);
        }

        public IMongoCollection<TEntity> GetCollection(string collection = null)
        {        
            return GetDatabase().GetCollection<TEntity>(collection, new MongoCollectionSettings{ });
        }
    }
}
