using JetStreamMongo.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace JetStreamMongo.DTOs.Request
{
    public class UpdateMitarbeiterRequestDTO
    {
        public string? Name { get; set; }

        
        public string? Benutzername { get; set; }

       
        public string? Passwort { get; set; }

        
        public string? Email { get; set; }

        
        public string? Telefonnummer { get; set; }

        
        public Role? Rolle { get; set; }
    }
}
