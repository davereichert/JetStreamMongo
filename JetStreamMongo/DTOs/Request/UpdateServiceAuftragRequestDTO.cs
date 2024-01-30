namespace JetStreamMongo.DTOs.Request
{
    public class UpdateServiceAuftragRequestDTO
    {
        public string? Priority { get; set; }
        public string? Service { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? PickupDate { get; set; }
    }

}
