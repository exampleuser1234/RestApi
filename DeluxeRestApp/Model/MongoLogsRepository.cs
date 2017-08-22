using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Models.LogsModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DeluxeRestApp.Model
{
    public class MongoLogsRepository : ILogsRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Log> _collection;

        public MongoLogsRepository()
        {
            _client = new MongoClient("mongodb://0.0.0.0:27017");
            _database = _client.GetDatabase("logsDB");
            _collection = _database.GetCollection<Log>("logs");
        }

        public async Task<Log> Insert(Log log)
        {
            await this._collection.InsertOneAsync(log);
            return await this.Get(log.Id.ToString());
        }

        public async Task<IEnumerable<Log>> Get()
        {
            var query = await this._collection.Find(new BsonDocument()).ToListAsync();
            return query;
        }

        public async Task<Log> Get(string id)
        {
            return await this._collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync();
        }
    }
}