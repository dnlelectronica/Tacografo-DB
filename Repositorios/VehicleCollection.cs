using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tacografo_DB.Modelos;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Tacografo_DB.Repositorios
{
    public class VehicleCollection : IVehicleCollection
    {
        internal MongoDBRep rep = new MongoDBRep();
        private IMongoCollection<Vehicle> mongoCollection;

        public VehicleCollection()
        {
            mongoCollection = rep.dataBase.GetCollection<Vehicle>("data");
        }

        public async Task DeleteVehicleData(string id)
        {
            var filter = Builders<Vehicle>.Filter.Eq(s => s.Id, new ObjectId(id));
            await mongoCollection.DeleteOneAsync(filter);
        }

        public async Task<List<Vehicle>> GetFullVehicleList()
        {
            return await mongoCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleById(string id)
        {
            return await mongoCollection.FindAsync(new BsonDocument
            {
                { "_id", new ObjectId(id) }
            }).Result.FirstAsync();
        }

        public async Task InsertVehicleData(Vehicle vehicle)
        {
            await mongoCollection.InsertOneAsync(vehicle);
        }

        public async Task UpdateVehicleData(Vehicle vehicle)
        {
            var filter = Builders<Vehicle>.Filter.Eq(s => s.Id, vehicle.Id);

            await mongoCollection.ReplaceOneAsync(filter, vehicle);
        }
    }
}
