using System.Collections.Generic;
using System;

namespace RRelationnelle.Modèles
{
    public class Admin : UserDto
    {

        private DateTime _creationDate { get; set; }
        private List<Citizen> _citizens { get; set; }
      /*  public Admin(int id, string fName, string lName, string email, string password, string login, bool activation, DateTime creationDate, List<Citizen> citizens) : base(id, fName, lName, email, password, login, activation, creationDate)
        {

            this._citizens = citizens;
        }*/

        public void DeleteUser()
        {

        }

        public void CreateCategory()
        {
        }

        public void DeleteCategory()
        {

        }


    }
}
