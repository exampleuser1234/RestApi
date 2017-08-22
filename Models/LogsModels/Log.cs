using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.LogsModels
{
    #region Usings
    #endregion

    public class Log
    {
        public ObjectId Id { get; set; }

        [BsonElement("Operation")]
        public Operation Operation { get; set; }

        [BsonElement("CardId")]
        public string CardId { get; set; }

        [BsonElement("CardNote")]
        public string CardNote { get; set; }

        [BsonElement("CardColumn")]
        public string CardColumn { get; set; }
    }
}
