﻿using AutoMapper;
using Commun.dto;
using Commun.Models;
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
                cfg.CreateMap<RessourceDto, Ressource>()

                .ForMember(dest =>
                   dest.ID_Ressource,
                   opt => opt.MapFrom(src => src._id))
                .ForMember(dest =>
                   dest.category,
                   opt => opt.MapFrom(src => new Category { Id_Category = src.idCateg }))
                .ForMember(dest =>
                    dest._url, opt => opt.MapFrom(src => src._url))
                .ForMember(dest =>
                    dest._title, opt => opt.MapFrom(src => src._title))
                .ForMember(dest =>
                    dest._reference, opt => opt.MapFrom(src => src.reference))
                .ForMember(dest =>
                    dest._user, opt => opt.MapFrom(src => src._user));

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
                    dest.Departement, opt => opt.MapFrom(src => src.departement))
                .ForMember(dest =>
                    dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode))
                .ForMember(dest =>
                    dest.emailContact, opt => opt.MapFrom(src => src.emailContact))
                .ReverseMap();

            });

            var mapper = new Mapper(config);
            return mapper;
        }

        public static Mapper MappingJob()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Job, JobDto>()

                .ForMember(dest =>
                   dest._id,
                   opt => opt.MapFrom(src => src.ID_Ressource))
                .ForMember(dest =>
                    dest._url, opt => opt.MapFrom(src => src._url))
                .ForMember(dest =>
                    dest._title, opt => opt.MapFrom(src => src._title))
                .ForMember(dest =>
                    dest.experience, opt => opt.MapFrom(src => src._experience))
                .ForMember(dest =>
                    dest.idCateg, opt => opt.MapFrom(src => src._Idcategory))
                .ForMember(dest =>
                    dest.Ville, opt => opt.MapFrom(src => src._Ville))
                .ForMember(dest =>
                    dest.Zipcode, opt => opt.MapFrom(src => src._Zipcode))
                .ForMember(dest =>
                    dest.Salaire, opt => opt.MapFrom(src => src._Salaire))
                 .ForMember(dest =>
                    dest.description, opt => opt.MapFrom(src => src._description))
                 .ForMember(dest =>
                    dest.TypeContrat, opt => opt.MapFrom(src => src._TypeContrat))
                .ReverseMap();

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
