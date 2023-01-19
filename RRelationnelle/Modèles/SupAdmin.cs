using System.Collections.Generic;
using System;

namespace RRelationnelle.Modèles
{
    public class SupAdmin : User
    {
        private List<Admin> _admins { get; set; }
        private List<Mod> _mods { get; set; }

        public SupAdmin(int id, string fName, string lName, string email, string password, string login, bool activation, DateTime creationDate, List<Admin> admins, List<Mod> mods) : base(id, fName, lName, email, password, login, activation, creationDate)
        {
            _admins = admins;
            _mods = mods;
        }

        public void CreateAdmin(User admin)
        {

        }

        public void DeleteAdmin(Admin admin)
        {

        }

        public void GrantMod()
        {

        }

        public void DenyMod()
        {

        }



    }
}
