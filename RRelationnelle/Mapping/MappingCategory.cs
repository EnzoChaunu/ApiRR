using AutoMapper;
using RessourcesRelationelles.Class;
using RRelationnelle.Modèles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Mapping
{
    public class MappingCategory : Profile
    {
        public static Mapper MappingCategoryL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Roles, Category>()

               .ForMember(dest =>
                   dest._name,
                   opt => opt.MapFrom(src => src._name))
              .ForMember(dest =>
                    dest._creationDate, src => src.Ignore())
                .ForMember(dest =>
                    dest.Id_Category, src => src.Ignore())
                .ForMember(dest =>
                    dest._creator, opt => opt.MapFrom(src => src.idcreator))
                .ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;



        }

    }
}
