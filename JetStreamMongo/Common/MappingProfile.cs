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
            CreateMap< Mitarbeiter, CreateMitarbeiterRequestDTO>();
            CreateMap<UpdateMitarbeiterRequestDTO, Mitarbeiter>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Mitarbeiter, UpdateMitarbeiterRequestDTO>();



            CreateMap<CreateServiceAuftragRequestDTO, ServiceAuftrag>();
            CreateMap<UpdateServiceAuftragRequestDTO, ServiceAuftrag>();





        }
    }
}
