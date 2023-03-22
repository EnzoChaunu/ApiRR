using AutoMapper;
using RRelationnelle.dto;
using RRelationnelle.Models;

namespace RRelationnelle.Mapping
{
    public class MappingRessource : Profile
    {
        public static Mapper MappingRessources()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ressource, RessourceDto>()

                .ForMember(dest =>
                   dest._id,
                   opt => opt.MapFrom(src => src.ID_Ressource))
                .ForMember(dest =>
                    dest._url, opt => opt.MapFrom(src => src._url))
                .ForMember(dest =>
                    dest._title, opt => opt.MapFrom(src => src._title))
                .ForMember(dest =>
                    dest.reference, opt => opt.MapFrom(src => src._reference))
                .ForMember(dest =>
                    dest._user, opt => opt.MapFrom(src => src._user))
                .ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;
        } 
        
        public static Mapper MappingAlternance()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Alternances, AlternanceDto>()

                .ForMember(dest =>
                   dest._id,
                   opt => opt.MapFrom(src => src.ID_Ressource))
                .ForMember(dest =>
                    dest._url, opt => opt.MapFrom(src => src._url))
                .ForMember(dest =>
                    dest._title, opt => opt.MapFrom(src => src._title))
                .ForMember(dest =>
                    dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest =>
                    dest.idCateg, opt => opt.MapFrom(src => src._Idcategory))
                .ForMember(dest =>
                    dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
                .ForMember(dest =>
                    dest.emailContact, opt => opt.MapFrom(src => src.emailContact))
                .ReverseMap();

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
