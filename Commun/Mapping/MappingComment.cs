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
                dest.)
            }
        }

    }
}
