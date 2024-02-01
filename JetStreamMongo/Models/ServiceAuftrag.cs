using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace JetStreamMongo.Models
{

    public class ServiceAuftrag
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("Priority")]
        public string Priority { get; set; }

        [BsonElement("Service")]
        public string Service { get; set; }

        
        public DateTime CreateDate { get; set; }

        
        public DateTime PickupDate { get; set; }
    }

}
