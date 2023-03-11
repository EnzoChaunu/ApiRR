using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    dest.title, opt => opt.MapFrom(src => src._title))
                .ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;



        }
    }
}
