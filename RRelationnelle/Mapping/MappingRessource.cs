using AutoMapper;
using RRelationnelle.dto;
using RRelationnelle.Models;
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
                    dest.title, opt => opt.MapFrom(src => src._title))
                .ForMember(dest =>
                    dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest =>
                    dest._category, opt => opt.MapFrom(src => src.category))
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
