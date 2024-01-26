namespace JetStreamMongo.DTOs.Request
{
    public class CreateMitarbeiterRequestDTO
    {
        public string Name { get; set; }
        public string Benutzername { get; set; }
        public string Passwort { get; set; } 
        public string Email { get; set; }
        public string Telefonnummer { get; set; }
        public string Rolle { get; set; }
    }
}
