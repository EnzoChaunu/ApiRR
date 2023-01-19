using System;

namespace RRelationnelle.Modèles
{
    public abstract class User
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

        public User(int id, string fName, string lName, string email, string password, string login, bool activation, DateTime creationDate)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Email = email;
            Password = password;
            Login = login;
            Activation = activation;
            CreationDate = creationDate;
        }
    }
}
