using AutoMapper;

namespace RRelationnelle
{
    public class MappinLog : Profile
    {
        public static Mapper LogMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>()

              .ForMember(dest =>
                  dest.Email,
                  opt => opt.MapFrom(src => src.Email))
             .ForMember(dest =>
                   dest.Password,
                    opt => opt.MapFrom(src => src.Password))
             .ForMember(dest =>
                   dest.Id_User,
                    opt => opt.MapFrom(src => src.Id))
             .ForMember(dest =>
                   dest.LName,
                    opt => opt.MapFrom(src => src.LName))
             .ForMember(dest =>
                   dest.FName,
                    opt => opt.MapFrom(src => src.FName))
             .ForMember(dest =>
                   dest.Login,
                    opt => opt.MapFrom(src => src.Login))
               .ReverseMap();

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
