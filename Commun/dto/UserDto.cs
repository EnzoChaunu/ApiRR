using System;

namespace RRelationnelle
{
    public class UserDto
    {
        //65108
        public int Id { get; private set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public bool Activation { get; set; }
        public DateTime CreationDate { get; set; }
        public Roles Role { get; set;}
        public int IdRole { get; set;}
    }
}
