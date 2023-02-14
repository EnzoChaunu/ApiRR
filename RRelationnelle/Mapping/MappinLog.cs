using AutoMapper;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Mapping
{
    public class MappinLog : Profile
    {

        public static Mapper MappingUser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>()

              .ForMember(dest =>
                  dest._email,
                  opt => opt.MapFrom(src => src.Email))
             .ForMember(dest =>
                   dest._password,
                    opt => opt.MapFrom(src => src.Password))
             .ForMember(dest =>
                   dest._lName,
                    opt => opt.MapFrom(src => src.LName))
             .ForMember(dest =>
                   dest._fName,
                    opt => opt.MapFrom(src => src.FName))
             .ForMember(dest =>
                   dest._login,
                    opt => opt.MapFrom(src => src.Login))
               .ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;



        }
    }
}
