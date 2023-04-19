﻿using AutoMapper;
using Commun.dto;

namespace RRelationnelle
{
    public class MappingUser : Profile
    {
        public static Mapper UserMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>()

               .ForMember(dest =>
                   dest.Id,
                   opt => opt.MapFrom(src => src.Id_User))
              .ForMember(dest =>
                    dest.Role,
                     opt => opt.MapFrom(src => src.Role))
              .ForMember(dest =>
                    dest.IdRole,
                     opt => opt.MapFrom(src => src.IdRole))
              .ForMember(dest => 
                    dest.FName,
                    opt => opt.MapFrom(src => src.FName))
              .ForMember(dest =>
                    dest.LName,
                    opt => opt.MapFrom(src => src.LName))
              .ForMember(dest =>
                    dest.Email,
                    opt => opt.MapFrom(src => src.Email))
              .ForMember(dest =>
                    dest.Password,
                    opt => opt.MapFrom(src => src.Password))
              .ForMember(dest =>
                    dest.Login,
                    opt => opt.MapFrom(src => src.Login))
              .ForMember(dest =>
                    dest.Activation,
                    opt => opt.MapFrom(src => src.Activation))
              .ForMember(dest =>
                    dest.CreationDate,
                    opt => opt.MapFrom(src => src.CreationDate))
                .ReverseMap();

            });

            var mapper = new Mapper(config);
            return mapper;
        }

        public static Mapper RolesMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Roles, RolesDto>()

               .ForMember(dest =>
                   dest.id_role,
                   opt => opt.MapFrom(src => src.id_role))
              .ForMember(dest =>
                    dest.name,
                     opt => opt.MapFrom(src => src.name))
              .ForMember(dest =>
                    dest.activated,
                     opt => opt.MapFrom(src => src.Activated))
                .ReverseMap();

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}