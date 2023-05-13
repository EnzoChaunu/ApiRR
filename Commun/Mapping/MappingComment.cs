using AutoMapper;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Mapping
{
    public class MappingComment
    {
        public static Mapper CommentMapperModelToDto()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDto>()

                .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.id_comments))
                .ForMember(dest =>
                dest.Content,
                opt => opt.MapFrom(src => src.content))
                .ForMember(dest =>
                dest.UserId,
                opt => opt.MapFrom(src => src.id_user.Id_User))
                .ForMember(dest =>
                dest.RessourceId,
                opt => opt.MapFrom(src => src.id_ressource.ID_Ressource))
                .ForMember(dest =>
                dest.Likes,
                opt => opt.MapFrom(src => src.likes))
                .ForMember(dest =>
                dest.Dislikes,
                opt => opt.MapFrom(src => src.dislikes))
                .ForMember(dest =>
                dest.Activation,
                opt => opt.MapFrom(src => src.activation))
                .ForMember(dest =>
                dest.Modified,
                opt => opt.MapFrom(src => src.modified))
                .ForMember(dest =>
                dest.ModificationDate,
                opt => opt.MapFrom(src => src.modificationDate))
                .ForMember(dest =>
                dest.CreationDate,
                opt => opt.MapFrom(src => src.creationDate))
                .ReverseMap();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
