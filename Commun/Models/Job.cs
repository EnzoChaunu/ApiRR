using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RRelationnelle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Models
{
    public class Job : Ressource
    {
        public string _description { get; set; }
        public string _experience { get; set; }
        public string _Ville { get; set; }
        public string _Salaire { get; set; }
        public string _Zipcode { get; set; }
        public string _TypeContrat { get; set; }

        public Job(string reference, string title,Category categ,  string url, User user, string descr, string exp, string ville, string salaire, string zipcod, string contrat) : base(reference, title,categ, url, user)
        {
            _description = descr;
            _experience = exp;
            _Ville = ville;
            _Salaire = salaire;
            _Zipcode = zipcod;
            _TypeContrat = contrat;

        }

        public Job()
        {
            
        }
    }
}
