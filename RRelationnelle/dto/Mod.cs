using System.Collections.Generic;
using System;

namespace RRelationnelle.Modèles
{
    public class Mod : UserDto
    {
        private List<Citizen> _citizens { get; set; }
        private List<Comment> _comments { get; set; }

     /*   public Mod(int id, string fName, string lName, string email, string password, string login, bool activation, DateTime creationDate, List<Citizen> citizens, List<Comment> comments) : base(id, fName, lName, email, password, login, activation, creationDate)
        {
            _citizens = citizens;
            _comments = comments;
        }*/


        public void DeleteCom()
        {

        }
    }
}
