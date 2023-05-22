using AutoMapper;
using RRelationnelle;

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
                dest.CreationDate,
                opt => opt.MapFrom(src => src.creationDate));
                
            });

            var mapper = new Mapper(config);
            return mapper;
        }

        public static Mapper CommentMapperDtoToModel(User user, Ressource ress)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommentDto, Comment>()

                .ForMember(dest =>
                dest.id_comments,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                dest.content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(dest =>
                dest.id_user,
                opt => opt.MapFrom(src => user))
                .ForMember(dest =>
                dest.id_ressource,
                opt => opt.MapFrom(src => ress))
                .ForMember(dest =>
                dest.likes,
                opt => opt.MapFrom(src => src.Likes))
                .ForMember(dest =>
                dest.dislikes,
                opt => opt.MapFrom(src => src.Dislikes))
                .ForMember(dest =>
                dest.activation,
                opt => opt.MapFrom(src => src.Activation))
                .ForMember(dest =>
                dest.modified,
                opt => opt.MapFrom(src => src.Modified))
                .ForMember(dest =>
                dest.creationDate,
                opt => opt.MapFrom(src => src.CreationDate));
               
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
