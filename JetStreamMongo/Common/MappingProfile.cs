using AutoMapper;
using JetStreamMongo.DTOs.Request;
using JetStreamMongo.DTOs.Respons;
using JetStreamMongo.Models;


namespace JetStreamMongo.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {


            // Responses
            CreateMap<Mitarbeiter, GetMitarbeiterResponseDTO>();
            CreateMap<ServiceAuftrag, GetServiceAuftragResponseDTO>();

            //Requests
            CreateMap<CreateMitarbeiterRequestDTO, Mitarbeiter>();

            CreateMap<CreateServiceAuftragRequestDTO, ServiceAuftrag>();
            CreateMap<UpdateServiceAuftragRequestDTO, ServiceAuftrag>();





        }
    }
}
