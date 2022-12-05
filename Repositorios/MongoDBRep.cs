using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tacografo_DB.Repositorios
{
    public class MongoDBRep
    {
        public MongoClient client;
        public IMongoDatabase dataBase;

        public MongoDBRep()
        {
            client = new MongoClient(MongoUrl.Create("mongodb://localhost:27017"));
            dataBase = client.GetDatabase("data");
        }
    }
}
