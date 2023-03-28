using System.Collections.Generic;
using System;

namespace RRelationnelle
{
    public class AdminDto : UserDto
    {
        private DateTime _creationDate { get; set; }
        private List<CitizenDto> _citizens { get; set; }
    }
}
