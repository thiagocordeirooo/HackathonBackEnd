using HackathonBackEnd.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace HackathonBackEnd.Data
{
    public class StorageBase<T> : IDisposable
    {
        private IMongoClient _mongoClient;

        protected string Colecao { get; private set; }
        protected IMongoDatabase _mongoDatabase;
        protected bool Disposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }
        public bool EstaDisponivel()
        {
            return _mongoDatabase != null;
        }
        public StorageBase(Colecoes colecao)
        {
            var porta = int.Parse(ConfigurationManager.AppSettings["MongoPorta"]);
            var server = ConfigurationManager.AppSettings["MongoServer"];
            var baseName = ConfigurationManager.AppSettings["BaseName"];
            var user = ConfigurationManager.AppSettings["UserBase"];
            var password = ConfigurationManager.AppSettings["PasswordBase"];
            var deveUsarSSL = ConfigurationManager.AppSettings["UseSSL"];
            var useSSL = true;

            if (!string.IsNullOrWhiteSpace(deveUsarSSL))
                useSSL = bool.Parse(deveUsarSSL);

            Colecao = colecao.ToString();
            MongoCredential credencial = MongoCredential.CreateCredential(baseName, user, password);
            var listaCredencial = new List<MongoCredential>();
            listaCredencial.Add(credencial);
            MongoClientSettings settings = new MongoClientSettings()
            {
                Server = new MongoServerAddress(server, porta),
                Credentials = listaCredencial,
                UseSsl = false
            };
            _mongoClient = new MongoClient($"mongodb://{user}:{password}@ds229295.mlab.com:29295/{baseName}");
            _mongoDatabase = _mongoClient.GetDatabase(baseName);
        }
        public virtual T BuscaPorId(ObjectId id)
        {
            var collection = _mongoDatabase.GetCollection<T>(Colecao);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return collection.Find(filter).FirstOrDefault();
        }
        public virtual void Insere(T entidade)
        {
            _mongoDatabase.GetCollection<T>(Colecao).InsertOne(entidade);
        }
        public virtual void Atualiza(T entidade)
        {
            _mongoDatabase.GetCollection<T>(Colecao).InsertOne(entidade);
        }
        public void Remove(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _mongoDatabase.GetCollection<T>(Colecao).DeleteOne(filter);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}