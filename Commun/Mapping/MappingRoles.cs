using AutoMapper;
using Commun.dto;

namespace RRelationnelle
{
    public class MappingRoles : Profile
    {
        public static Mapper MappingUserLog()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>()

               .ForMember(dest =>
                   dest.Id,
                   opt => opt.MapFrom(src => src.Id_User))
              .ForMember(dest =>
                    dest.IdRole,
                     opt => opt.MapFrom(src => src.IdRole))
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
