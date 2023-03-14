using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle.Models
{
    public class RessourceStat
    {

        [Key]
        public int Idressourcestat { get; set; }

        [Column]
        public int _view { get; set; }
        public int _shares { get; set; }
        public int _likes { get; set; }
        public int _dislikes { get; set; }
        public int _saved { get; set; }
        public DateTime _date { get; set; }

        [ForeignKey("ID_Ressource")]
        public Ressource ressource { get; set; }
    }
}
