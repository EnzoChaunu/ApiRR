using System;

namespace RRelationnelle
{
    public class CategoryDto
    {

        public int Id_Category { get; set; }
        public int _creator { get; set; }
        public string _name { get; set; }
        private UserDto user { get; }
        public DateTime _creationDate { get;}

        public bool IsValid {get;}
    }
}
