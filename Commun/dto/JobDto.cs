using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.dto
{
    public class JobDto : RessourceDto
    {
        public string description { get; set; }
        public string experience { get; set; }
        public string Ville { get; set; }
        public string Salaire { get; set; }
        public string Zipcode { get; set; }
        public string TypeContrat { get; set; }

        public JobDto(string title, int categoryId, string _reference, string url, int userId,string descr, string exp, string ville,string salaire,string zipcod,string contrat) : base(title, categoryId, _reference, url, userId)
        {
            description = descr;
            experience = exp;
            Ville = ville;
            Salaire = salaire;
            Zipcode = zipcod;
            TypeContrat = contrat;
            
        }


    }
}
