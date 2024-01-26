namespace JetStreamMongo.DTOs.Respons
{
    public class DeleteResponse_DTO
    {
        public string Id { get; set; }

        public void DeleteResponse(string id)
        {
            Id = id;
        }

    }
   
}
