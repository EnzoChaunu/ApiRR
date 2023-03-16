using AutoMapper;


namespace RRelationnelle
{
    public class MappingCategory : AutoMapper.Profile
    {
        public static Mapper MappingCategoryL()
        {
            var config =  new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Categorie, CategoryDto>()

                .ForMember(dest =>
                   dest._name,
                   opt => opt.MapFrom(src => src._name))
                .ForMember(dest =>
                    dest._creationDate, src => src.Ignore())
                .ForMember(dest =>
                    dest.Id_Category, opt => opt.MapFrom(src => src.Id_Category))
                .ForMember(dest =>
                    dest._creator, opt => opt.MapFrom(src => src.idcreator))
                .ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;



        }

    }
}
