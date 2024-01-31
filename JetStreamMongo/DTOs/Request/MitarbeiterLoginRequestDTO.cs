using MongoDB.Bson.Serialization.Attributes;

namespace JetStreamMongo.DTOs.Request
{
    public class MitarbeiterLoginRequestDTO
    {
       
        public string Benutzername { get; set; }

        
        public string Passwort { get; set; }
    }
}
