namespace Models.LogsModels
{
    #region Using statements
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    #endregion

    public class Log
    {
        #region Properties
        public ObjectId Id { get; set; }

        [BsonElement("Operation")]
        public Operation Operation { get; set; }

        [BsonElement("CardId")]
        public string CardId { get; set; }

        [BsonElement("CardNote")]
        public string CardNote { get; set; }

        [BsonElement("CardColumn")]
        public string CardColumn { get; set; }
        #endregion
    }
}
