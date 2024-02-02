using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JetStreamMongo.Models
{
    /// <summary>
    /// Represents an employee within the system.
    /// </summary>

    public class Mitarbeiter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Benutzername")]
        public string Benutzername { get; set; }

        [BsonElement("Passwort")]
        public string Passwort { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Telefonnummer")]
        public string Telefonnummer { get; set; }

        [BsonElement("Rolle")]
        [BsonRepresentation(BsonType.String)]
        public Role Rolle { get; set; }
    }

}
