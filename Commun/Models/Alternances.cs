using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Models
{
    public class Alternances : Ressource
    {
        public readonly string DiplomaLevel;
        public readonly string Period;
        public readonly string Capacity;
        public readonly string Ville;
        public readonly string Zipcode;
        public readonly string emailContact;

        public Alternances(string reference, string title, Category categ, string url, User user, string diplome, string perio, string cap, string city, string cod, string email) : base(reference,title, categ,url,user)
        {
            DiplomaLevel = diplome;
            Period = perio;
            Capacity = cap;
            Ville = city;
            Zipcode = cod;
            emailContact = email;

        }
    }
}
