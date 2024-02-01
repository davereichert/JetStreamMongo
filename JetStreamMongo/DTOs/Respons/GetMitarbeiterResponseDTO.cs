using JetStreamMongo.Models;

namespace JetStreamMongo.DTOs.Respons
{
    public class GetMitarbeiterResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Benutzername { get; set; }
        // Passwort sollte nicht im Response enthalten sein
        public string Email { get; set; }
        public string Telefonnummer { get; set; }
        public Role Rolle { get; set; }
    }
}
