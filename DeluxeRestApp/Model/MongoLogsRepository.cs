namespace DeluxeRestApp.Model
{
    #region Using statements
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models.LogsModels;
    using Models;
    using MongoDB.Bson;
    using MongoDB.Driver;
    #endregion

    public class MongoLogsRepository : ILogsRepository
    {
        #region Private fields
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Log> _collection;
        #endregion

        #region Constructor
        public MongoLogsRepository()
        {
            _client = new MongoClient(Constants.MongoClientAddress);
            _database = _client.GetDatabase(Constants.DatabaseName);
            _collection = _database.GetCollection<Log>(Constants.CollectionName);
        }
        #endregion

        #region Implementation of ILogsRepository
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
        #endregion
    }
}