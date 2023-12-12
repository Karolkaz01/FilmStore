using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class RentedFilmDto
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("clientFirstName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string ClientFirstName { get; set; }
        [BsonElement("clientLastName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string ClientLastName { get; set; }
        [BsonElement("clientAdressEmail"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string ClientAdressEmail { get; set; }
        [BsonElement("filmTitle"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string FilmTitle { get; set; }
        [BsonElement("rentDate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]

        public DateTime RentDate { get; set; }
        [BsonElement("planedReturnDate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]

        public DateTime PlanedReturnDate { get; set; }
        [BsonElement("returnDate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime? ReturnDate { get; set; }
    }
}
