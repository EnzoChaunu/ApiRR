using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class SupAdminDto : UserDto
    {
        private List<AdminDto> _admins { get; set; }
        private List<ModDto> _mods { get; set; }
    }
}
