using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class ModDto : UserDto
    {
        private List<CitizenDto> _citizens { get; set; }
        private List<CommentDto> _comments { get; set; }
    }
}
