using AutoMapper;

namespace RRelationnelle
{
    public class MappingCategory : Profile
    {
       

        public static Mapper MappingCategoryToDto()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDto>()

                .ForMember(dest =>
                   dest._name,
                   opt => opt.MapFrom(src => src._name))
                .ForMember(dest =>
                    dest._creationDate, src => src.Ignore())
                .ForMember(dest =>
                    dest.Id_Category, opt => opt.MapFrom(src => src.Id_Category))
                .ForMember(dest =>
                    dest._creator, opt => opt.MapFrom(src => src.Creator.Id_User));
               

            });

            var mapper = new Mapper(config);
            return mapper;
        }

        public static Mapper MappingCategoryTomodel(User us)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDto, Category>()

                .ForMember(dest =>
                   dest._name,
                   opt => opt.MapFrom(src => src._name))
                .ForMember(dest =>
                    dest._creationDate, src => src.Ignore())
                .ForMember(dest =>
                    dest.Id_Category, opt => opt.MapFrom(src => src.Id_Category))
                .ForMember(dest =>
                    dest.Creator, opt => opt.MapFrom(src => us));
                

            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
