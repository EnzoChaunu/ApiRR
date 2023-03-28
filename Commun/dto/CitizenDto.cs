using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class CitizenDto : UserDto
    {
        private List<Ressource> _favRessources { get; set; }
        private List<CommentDto> _comments { get; set; }
    }
}
