using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Models
{
    [Serializable]
    public class FilmDto
    {
        [BsonId,BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("title"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string Title { get; set; }
        [BsonElement("director"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string Director { get; set; }
        [BsonElement("type"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string Type { get; set; }
        [BsonElement("addDate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]

        public DateTime AddDate { get; set; }
        [BsonElement("actors"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public IEnumerable<string> Actors { get; set; }
        [BsonElement("rate"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]

        public int Rate { get; set; }
        [BsonElement("summary"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string Summary { get; set; }

        [BsonElement("time"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]

        public int Time { get; set; }

        [BsonElement("isInStock"), BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]

        public bool IsInStock { get; set; }
    }
}
