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

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("priority")]
        public string Priority { get; set; }

        [BsonElement("service")]
        public string Service { get; set; }

        [BsonElement("create_date")]
        public DateTime CreateDate { get; set; }

        [BsonElement("pickup_date")]
        public DateTime PickupDate { get; set; }
    }

}
