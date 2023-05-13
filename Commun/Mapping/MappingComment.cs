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
            );
        }

    }
}
