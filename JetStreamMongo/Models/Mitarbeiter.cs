using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JetStreamMongo.Models
{

    public class Mitarbeiter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("username")]
        public string Benutzername { get; set; }

        [BsonElement("password")]
        public string Passwort { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("telephone")]
        public string Telefonnummer { get; set; }

        [BsonElement("role")]
        public string Rolle { get; set; }
    }

}
