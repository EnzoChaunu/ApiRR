using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.dto
{
    public class AlternanceDto : RessourceDto
    {
        public readonly string DiplomaLevel;
        public readonly string LienAnnonce;
        public readonly string Period;
        public readonly string Capacity;
        public readonly string Ville;
        public readonly string Zipcode;
        public readonly string emailContact;

     /*   public AlternanceDto(string reference,string title,CategoryDto categ,string diplome,string lien,string perio,string cap,string city,string cod,string email):base(reference,title)
        {
            DiplomaLevel = diplome;
            LienAnnonce = lien;
            Period = perio;
            Capacity = cap;
            Ville = city;
            Zipcode = cod;
            emailContact = email;

        }*/
    }
}
