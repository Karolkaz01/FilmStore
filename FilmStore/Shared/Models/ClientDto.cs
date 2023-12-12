using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ClientDto
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("firstName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; }

        [BsonElement("lastName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; }

        [BsonElement("adressEmail"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string AdressEmail { get; set; }

        [BsonElement("phoneNr"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string PhoneNr { get; set; }

        [BsonElement("registrationDate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        [BsonElement("rentedFilms"), BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int RentedFilms { get; set; }

        [BsonElement("password"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Password { get; set; }
    }
}
