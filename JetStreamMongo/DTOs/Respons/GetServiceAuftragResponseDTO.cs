namespace JetStreamMongo.DTOs.Respons
{
    public class GetServiceAuftragResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Priority { get; set; }
        public string Service { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
