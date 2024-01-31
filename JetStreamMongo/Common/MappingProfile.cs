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
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Mitarbeiter, UpdateMitarbeiterRequestDTO>();

            CreateMap<MitarbeiterLoginRequestDTO, Mitarbeiter>();
            CreateMap<Mitarbeiter, MitarbeiterLoginRequestDTO > ();



            CreateMap<CreateServiceAuftragRequestDTO, ServiceAuftrag>();
            CreateMap<UpdateServiceAuftragRequestDTO, ServiceAuftrag>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));






        }
    }
}
