using AutoMapper;

namespace RRelationnelle
{
    public class MappingRoles : Profile
    {
        public static Mapper MappingUserLog()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap< User, UserDto>()

               .ForMember(dest =>
                   dest.Id,
                   opt => opt.MapFrom(src => src._email))
              .ForMember(dest =>
                    dest.Password,
                     opt => opt.MapFrom(src => src._password))
                .ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;



        }
    }
}
